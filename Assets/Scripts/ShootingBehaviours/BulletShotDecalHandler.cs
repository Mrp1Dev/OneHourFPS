using UnityEngine;

public class BulletShotDecalHandler : ShootingBehaviour
{
    [SerializeField] private GameObject decalPrefab;

    protected override void OnBulletHit(RaycastHit hit)
    {
        var offset = Random.Range(0.03f, 0.05f);
        Instantiate(decalPrefab, hit.point + hit.normal * offset, Quaternion.LookRotation(-hit.normal), hit.transform);
    }
}
