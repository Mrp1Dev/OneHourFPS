using UnityEngine;
using Mirror;
public abstract class NetworkShootingBehaviour : NetworkBehaviour
{
    [SerializeField] protected ShootingHandler shootingHandler;

    protected virtual void Reset()
    {
        shootingHandler = GetComponent<ShootingHandler>();
    }

    protected virtual void OnEnable()
    {
        shootingHandler.BulletShot += OnShoot;
        shootingHandler.BulletHit += OnBulletHit;
    }

    protected virtual void OnDisable()
    {
        shootingHandler.BulletShot -= OnShoot;
        shootingHandler.BulletHit -= OnBulletHit;
    }

    protected virtual void OnShoot() { }
    protected virtual void OnBulletHit(RaycastHit hit) { }
}

public abstract class ShootingBehaviour : MonoBehaviour
{
    [SerializeField] protected ShootingHandler shootingHandler;

    protected virtual void Reset()
    {
        shootingHandler = GetComponent<ShootingHandler>();
    }

    protected virtual void OnEnable()
    {
        shootingHandler.BulletShot += OnShoot;
        shootingHandler.BulletHit += OnBulletHit;
    }

    protected virtual void OnDisable()
    {
        shootingHandler.BulletShot -= OnShoot;
        shootingHandler.BulletHit -= OnBulletHit;
    }

    protected virtual void OnShoot() { }
    protected virtual void OnBulletHit(RaycastHit hit) { }
}