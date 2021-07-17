using UnityEngine;

public class UnscaledChild : MonoBehaviour
{
    Vector3 baseScale;
    private void Start()
    {
        if (transform.parent == null) return;
        Vector3 scaleTmp = transform.localScale;
        scaleTmp.x /= transform.parent.localScale.x;
        scaleTmp.y /= transform.parent.localScale.z;
        transform.localScale = scaleTmp;
    }
}
