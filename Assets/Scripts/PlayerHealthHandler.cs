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

    [Command(requiresAuthority = false)]
    private void CmdTakeDamage(GameObject player, int damage)
    {
        var handler = player.GetComponent<PlayerHealthHandler>();
        handler.currentHealth -= damage;
        CallHealthUpdate(handler.GetComponent<NetworkIdentity>().connectionToClient, handler.currentHealth);
        if (handler.currentHealth <= 0)
        {
            NetworkServer.Destroy(gameObject);
        }
    }
}
