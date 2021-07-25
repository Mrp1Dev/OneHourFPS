using UnityEngine;
using Mirror;
using MUtility;
public class LayerChanger : NetworkBehaviour 
{
    [Tooltip("DO NOT SET THIS TO MORE THAN ONE LAYER.")]
    [SerializeField] private LayerMask localCharacterLayer;
    [Tooltip("DO NOT SET THIS TO MORE THAN ONE LAYER.")]
    [SerializeField] private LayerMask multiplayerCharacterLayer;
    
    private void Start()
    {
        Camera.onPreRender += OnPreRenderCallback;
    }

    private void OnDestroy()
    {
        Camera.onPreRender -= OnPreRenderCallback;
    }
    private void OnPreRenderCallback(Camera _)
    {
        var layer = hasAuthority ? MUtils.MaskToIndex(localCharacterLayer) : MUtils.MaskToIndex(multiplayerCharacterLayer);
        gameObject.SetLayerIncludingChildren(layer);
    }

}
