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
    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private float magzineAmmo;
    [SerializeField] private float totalAmmo;
    private float ammo;

    private float timer;

    private void Start()
    {
        ammo = magzineAmmo;
        UpdateText();
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
                UpdateText();

                timer = 1f / (RPM / 60.0f);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            var needed = magzineAmmo - ammo;
            var diff = totalAmmo >= needed ? needed : totalAmmo;
            ammo += diff;
            totalAmmo -= diff;
            UpdateText();
        }

        timer -= Time.deltaTime;
    }

    void UpdateText()
    {
        ammoText.text = $"Ammo: {ammo} / {totalAmmo}"; ;
    }
}
