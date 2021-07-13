using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    const string MouseVerticalAxis = "Mouse Y";
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        float delta = rotateSpeed * Input.GetAxis(MouseVerticalAxis);
        delta = Mathf.Clamp(delta, -Vector3.Angle(transform.forward, Vector3.down), Vector3.Angle(transform.forward, Vector3.up));
        transform.localRotation = Quaternion.Euler(Vector3.left * delta) * transform.localRotation;
    }
}
