using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(CameraTransformManager))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _playerCar;

    private readonly float _offsetY = 12f;
    private readonly float _offsetZ = -8f;
    private readonly float deltaOffsetY = 5f;

    private Transform _transform;

    private CameraTransformManager _transformSwitcher;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _transformSwitcher = GetComponent<CameraTransformManager>();

        PauseManager.Instance.OnPaused += SetPause;
    }
    private void Start()
    {
        _transformSwitcher.Initialize(new Vector3(0, _offsetY, _offsetZ),new Vector3(0, _offsetY+ deltaOffsetY, -_offsetZ-1), _transform.eulerAngles.x, 90f);
    }

    void Update()
    {
        FollowPlayerCar();
    }

    private void OnDestroy()
    {
        PauseManager.Instance.OnPaused -= SetPause;
    }

    private void FollowPlayerCar()
    {  
        _transform.position = _playerCar.position + _transformSwitcher.Offset;
        _transform.rotation = Quaternion.Euler(_transformSwitcher.Angle, 0, 0);
    }

    private void SetPause(bool isPaused)
    {
        enabled = !isPaused;
    }
}
