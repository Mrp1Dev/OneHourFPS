using UnityEngine;
using Mirror;
public class PlayerHealthHandler : NetworkBehaviour
{
    [SyncVar, SerializeField]
    private int currentHealth;
    public event System.Action<int> HealthUpdated;

    private void Start() => HealthUpdated?.Invoke(currentHealth);

    public void TakeDamage(int damage)
    {
        CmdTakeDamage(gameObject, damage);
    }

    [TargetRpc]
    private void CallHealthUpdate(NetworkConnection target, int newHealth)
    {
        HealthUpdated?.Invoke(newHealth);
    }


    [TargetRpc]
    private void QuitGame(NetworkConnection target)
    {
        Application.Quit();
    }

    [Command(requiresAuthority = false)]
    private void CmdTakeDamage(GameObject player, int damage)
    {
        var handler = player.GetComponent<PlayerHealthHandler>();
        handler.currentHealth -= damage;
        var connection = handler.GetComponent<NetworkIdentity>().connectionToClient;
        CallHealthUpdate(connection, handler.currentHealth);
        if (handler.currentHealth <= 0)
        {
            QuitGame(connection);
        }
    }
}
