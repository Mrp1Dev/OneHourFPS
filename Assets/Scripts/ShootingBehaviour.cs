using UnityEngine;

public abstract class ShootingBehaviour : MonoBehaviour
{
    [SerializeField] protected ShootingHandler shootingHandler;

    protected virtual void OnEnable()
    {
        shootingHandler.BulletShot += OnShoot;
    }

    protected virtual void OnDisable()
    {
        shootingHandler.BulletShot -= OnShoot;
    }

    protected abstract void OnShoot();
}
