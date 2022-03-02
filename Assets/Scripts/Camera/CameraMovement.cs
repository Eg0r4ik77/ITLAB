using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(CameraTransformSwitcher))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _playerCar;

    [SerializeField]
    private float _offsetY = 12f;

    [SerializeField]
    private float _offsetZ = -8f;

    [SerializeField]
    private float deltaOffsetY = 5f;

    private Transform _transform;

    private CameraTransformSwitcher _transformSwitcher;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _transformSwitcher = GetComponent<CameraTransformSwitcher>();
    }
    private void Start()
    {
        _transformSwitcher.Initialize(new Vector3(0, _offsetY, _offsetZ),new Vector3(0, _offsetY+ deltaOffsetY, -_offsetZ), _transform.eulerAngles.x, 90f);
    }

    void Update()
    {
        FollowPlayerCar();
    }

    private void FollowPlayerCar()
    {  
        _transform.position = _playerCar.position + _transformSwitcher.Offset;
        _transform.rotation = Quaternion.Euler(_transformSwitcher.Angle, 0, 0);
    }
 
}
