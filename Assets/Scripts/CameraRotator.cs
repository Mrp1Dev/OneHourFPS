using UnityEngine;
using Mirror;
using MUtility;

public class CameraRotator : MonoBehaviour
{
    const string MouseVerticalAxis = "Mouse Y";
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float shootingSenstivityMultiplier;
    [SerializeField, TryParentInit] private NetworkIdentity identity;

    private void Update()
    {
        if (!identity.hasAuthority) return; 
        float delta = rotateSpeed * Input.GetAxis(MouseVerticalAxis) * (Input.GetMouseButton(0) ? shootingSenstivityMultiplier : 1f);
        delta = Mathf.Clamp(delta, -Vector3.Angle(transform.forward, Vector3.down), Vector3.Angle(transform.forward, Vector3.up));
        transform.localRotation = Quaternion.Euler(Vector3.left * delta) * transform.localRotation;
    }
}
