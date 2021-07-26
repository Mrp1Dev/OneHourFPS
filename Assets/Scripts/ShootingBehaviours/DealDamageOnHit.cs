using UnityEngine;

public class DealDamageOnHit : ShootingBehaviour
{
    [SerializeField] private int damage;
    protected override void OnBulletHit(RaycastHit hit)
    {
        if(hit.transform.TryGetComponent<PlayerHealthHandler>(out var health))
        {
            health.TakeDamage(damage);
        }
    }
}
