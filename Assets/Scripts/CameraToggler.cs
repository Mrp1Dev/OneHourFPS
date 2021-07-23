using UnityEngine;
using Mirror;
using System.Collections.Generic;

public class CameraToggler : NetworkBehaviour
{
    [SerializeField] private List<GameObject> cams;
    void Update()
    {
        cams.ForEach(c => c.SetActive(hasAuthority));
    }
}
