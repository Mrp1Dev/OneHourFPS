using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [Header("Main Shooting")]
    [SerializeField] private LayerMask hittable;
    [SerializeField] private float hitForce;
    [SerializeField] private float RPM;
    [Header("Sound")]
    [SerializeField] private AudioSource shootSoundEffect;

    [Header("Ammo")]
    [SerializeField] private int magzineAmmo;
    [SerializeField] private int totalAmmo;

    [Header("Weapon Recoil")]
    [SerializeField] private AnimationCurve weaponPushbackCurve;
    [SerializeField] private float weaponPushbackMagnitude;
    [SerializeField] private Transform weapon;
    private Vector3 baseWeaponOffset;

    public event Action BulletShot;
    public event Action<int> CurrentAmmoUpdated;
    public event Action<int> TotalAmmoUpdated;

    private int ammo;

    private float timer;

    private void Start()
    {
        baseWeaponOffset = weapon.localPosition;
        ammo = magzineAmmo;
        CurrentAmmoUpdated?.Invoke(ammo);
        TotalAmmoUpdated?.Invoke(totalAmmo);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && ammo > 0)
        {
            if (timer <= 0.0f)
            {
                Ray ray = new Ray(cam.position, cam.forward);
                if (Physics.Raycast(ray, out var res, Mathf.Infinity, hittable))
                {
                    res.transform.GetComponent<Rigidbody>().AddForceAtPosition(cam.forward * hitForce, res.point, ForceMode.Impulse);
                }

                shootSoundEffect.Play();

                ammo--;

                StartCoroutine(AnimateWeapon());

                timer = 1f / (RPM / 60.0f);
                BulletShot?.Invoke();
                CurrentAmmoUpdated?.Invoke(ammo);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            var needed = magzineAmmo - ammo;
            var diff = totalAmmo >= needed ? needed : totalAmmo;
            ammo += diff;
            totalAmmo -= diff;
            CurrentAmmoUpdated?.Invoke(ammo);
            TotalAmmoUpdated?.Invoke(totalAmmo);
        }

        timer -= Time.deltaTime;
    }

    private IEnumerator AnimateWeapon()
    {
        float timeSinceShoot = 0.0f;
        do
        {
            print(timeSinceShoot / (RPM / 60.0f));
            var offset = -(weapon.localRotation * Vector3.forward) * weaponPushbackCurve.Evaluate(timeSinceShoot / (1.0f / (RPM / 60.0f))) * weaponPushbackMagnitude;
            weapon.localPosition = baseWeaponOffset + offset;
            timeSinceShoot += Time.deltaTime;
            yield return null;
        } while (timeSinceShoot / (1.0f / (RPM / 60.0f)) < 1.0f);
        weapon.localPosition = baseWeaponOffset;
    } 
}
