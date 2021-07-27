using UnityEngine;
using Mirror;
public class PushBoxesOnHit : NetworkShootingBehaviour
{
    [SerializeField] private LayerMask hittableLayers;
    [SerializeField] private float hitForce;
    [SerializeField] private Camera cam;

    protected override void OnBulletHit(RaycastHit hit)
    {
        if(((1 << hit.transform.gameObject.layer) & hittableLayers) != 0)
        {
            CmdAddForceAtPosition(hit.transform.gameObject, cam.transform.forward * hitForce, hit.point, ForceMode.Impulse);
        }
    }

    [Command]
    private void CmdAddForceAtPosition(GameObject target, Vector3 force, Vector3 pos, ForceMode mode)
    {
        target.GetComponent<Rigidbody>().AddForceAtPosition(force, pos, mode);
    }
}
