using UnityEngine;

public class PushBoxesOnHit : ShootingBehaviour
{
    [SerializeField] private LayerMask hittableLayers;
    [SerializeField] private float hitForce;
    [SerializeField] private Camera cam;

    protected override void OnBulletHit(RaycastHit hit)
    {
        if(((1 << hit.transform.gameObject.layer) & hittableLayers) != 0)
        {
            hit.transform.GetComponent<Rigidbody>().AddForceAtPosition(cam.transform.forward * hitForce, hit.point, ForceMode.Impulse);
        }
    }
}
