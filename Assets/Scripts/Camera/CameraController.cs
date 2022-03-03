using UnityEngine;

[RequireComponent(typeof(CameraTransformSwitcher))]
public class CameraController : MonoBehaviour
{
    private CameraTransformSwitcher _cameraSwitcher;

    private void Awake()
    {
        _cameraSwitcher = GetComponent<CameraTransformSwitcher>();
    }

    public void OnTransformed(bool is2D)
    {
        _cameraSwitcher.SwitchCamera(is2D);
    }
}
