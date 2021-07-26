using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private PlayerHealthHandler healthHandler;

    private void Awake() => healthHandler.HealthUpdated += OnHealthUpdated;

    private void OnDestroy() => healthHandler.HealthUpdated -= OnHealthUpdated;

    private void OnHealthUpdated(int newHealth)
    {
        GetComponent<TMP_Text>().text = $"Health: {newHealth}";
    }
}
