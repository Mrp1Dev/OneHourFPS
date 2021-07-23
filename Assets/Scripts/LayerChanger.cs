using UnityEngine;
using Mirror;
public class LayerChanger : NetworkBehaviour 
{
    [Tooltip("DO NOT SET THIS TO MORE THAN ONE LAYER.")]
    [SerializeField] private LayerMask localCharacterLayer;
    [Tooltip("DO NOT SET THIS TO MORE THAN ONE LAYER.")]
    [SerializeField] private LayerMask multiplayerCharacterLayer;
    [SerializeField] private GameObject gun;
    private void OnPreRender()
    {
        var layer = hasAuthority ? MaskToIndex(localCharacterLayer) : MaskToIndex(multiplayerCharacterLayer);
        gameObject.layer = layer;
        
        if (gun) gun.layer = layer;
    }

    private int MaskToIndex(LayerMask mask) => Mathf.RoundToInt(Mathf.Log((float)mask.value, 2f));
}
