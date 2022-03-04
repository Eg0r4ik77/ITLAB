using UnityEngine;

[RequireComponent(typeof(PlayerCarMovement))]
[RequireComponent(typeof(Transform))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CarConverter _carConverter;

    [SerializeField]
    private CameraController _camera;

    [SerializeField]
    private RoadPrefab _specialRoad;

    private PlayerCarMovement _movement;
    private Transform _transform;
    private GameSpaceManager _gameSpaceManager;

    private void Awake()
    {
        _movement = GetComponent<PlayerCarMovement>();
        _transform = GetComponent<Transform>();
        _gameSpaceManager = gameObject.AddComponent<GameSpaceManager>();
    }

    private void OnEnable()
    {
        _gameSpaceManager.OnGameSpaceChanged += _camera.Transform;
        _gameSpaceManager.OnGameSpaceChanged += _carConverter.ConvertCars;
    }

    private void OnDisable()
    {
        _gameSpaceManager.OnGameSpaceChanged -= _camera.Transform;
        _gameSpaceManager.OnGameSpaceChanged -= _carConverter.ConvertCars;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float distanceBeforeSwitchingTo2D = _transform.position.z - _specialRoad.Back.z;
        float distanceBeforeSwitchingTo3D = _specialRoad.Front.z - _transform.position.z;
       
        _movement.Shift(horizontal, vertical);
        
        if (Mathf.Abs(distanceBeforeSwitchingTo2D) < 1)
        {
            _gameSpaceManager.TryChangeSpace(GameSpace.Space2D);
        }

        if (Mathf.Abs(distanceBeforeSwitchingTo3D) < 1)
        {
            _gameSpaceManager.TryChangeSpace(GameSpace.Space3D);
        }
    }
}