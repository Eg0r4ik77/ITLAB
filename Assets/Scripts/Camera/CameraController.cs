using UnityEngine;

[RequireComponent(typeof(CameraTransformManager))]
public class CameraController : MonoBehaviour
{
    private CameraTransformManager _cameraTransformManager;

    private void Awake()
    {
        _cameraTransformManager = GetComponent<CameraTransformManager>();
    }

    public void Transform(GameSpace gameSpace)
    {
        _cameraTransformManager.SwitchCamera(gameSpace);
    }
}
