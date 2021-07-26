using UnityEngine;
using Mirror;
using System.Collections.Generic;

public class ObjectToggler : NetworkBehaviour
{
    [SerializeField] private List<GameObject> objectsToToggle;
    void Update()
    {
        objectsToToggle.ForEach(c => c.SetActive(hasAuthority));
    }
}
