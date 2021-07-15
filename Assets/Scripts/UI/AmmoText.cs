using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    [SerializeField] private ShootingHandler shootingHandler;
    [SerializeField] private TMP_Text text;
    private int lastCurrentAmmo;
    private int lastTotalAmmo;
    private void Awake()
    {
        shootingHandler.CurrentAmmoUpdated += OnCurrentAmmoUpdate;
        shootingHandler.TotalAmmoUpdated += OnTotalAmmoUpdate;
    }

    private void OnDestroy()
    {
        shootingHandler.CurrentAmmoUpdated -= OnCurrentAmmoUpdate;
        shootingHandler.TotalAmmoUpdated -= OnTotalAmmoUpdate;
    }

    private void OnCurrentAmmoUpdate(int ammo)
    {
        lastCurrentAmmo = ammo;
        text.text = GetAmmoString(ammo, lastTotalAmmo);
    }

    private void OnTotalAmmoUpdate(int ammo)
    {
        lastTotalAmmo = ammo;
        text.text = GetAmmoString(lastCurrentAmmo, ammo);
    }

    private string GetAmmoString(int ammo, int total)
    {
        return $"Ammo: {ammo} / {total}";
    }
}
