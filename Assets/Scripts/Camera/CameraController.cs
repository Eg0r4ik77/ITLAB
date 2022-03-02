using UnityEngine;

[RequireComponent(typeof(CameraTransformSwitcher))]
public class CameraController : MonoBehaviour
{
    private CameraTransformSwitcher _cameraSwitcher;

    private void Awake()
    {
        _cameraSwitcher = GetComponent<CameraTransformSwitcher>();
    }

    public void OnTransformedTo2D()
    {
        _cameraSwitcher.SwitchCamera(false);
    }
    public void OnTransformedTo3D()
    {
        _cameraSwitcher.SwitchCamera(true);
    }
}
