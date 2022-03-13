using System;
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

    private int _startPlayerPosition;

    public int Score { get; private set; }

    public event Action<int> OnDied;

    private void Awake()
    {
        _movement = GetComponent<PlayerCarMovement>();
        _transform = GetComponent<Transform>();

        _gameSpaceManager = gameObject.AddComponent<GameSpaceManager>();

        _gameSpaceManager.OnGameSpaceChanged += _camera.Transform;
        _gameSpaceManager.OnGameSpaceChanged += _carConverter.ConvertCars;
    }

    private void Start()
    {
        _startPlayerPosition = (int)_transform.position.z;    
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float distanceBeforeSwitchingTo2D = _transform.position.z - _specialRoad.Back.z;
        float distanceBeforeSwitchingTo3D = _specialRoad.Front.z - _transform.position.z;

        if (_movement.enabled == true)
        {
            _movement.Shift(horizontal, vertical);
            Score = (int)(_transform.position.z - _startPlayerPosition) / 4;

            if (Mathf.Abs(distanceBeforeSwitchingTo2D) < 1f)
            {
                _gameSpaceManager.TryChangeSpace(GameSpace.Space2D);
                _movement.TrySetSpeedUp(true);
            }

            if (Mathf.Abs(distanceBeforeSwitchingTo3D) < 9.5f)
            {
                _gameSpaceManager.TryChangeSpace(GameSpace.Space3D);
                _movement.TrySetSpeedUp(false);
            }
        }
    }

    private void OnDestroy()
    {
        _gameSpaceManager.OnGameSpaceChanged -= _camera.Transform;
        _gameSpaceManager.OnGameSpaceChanged -= _carConverter.ConvertCars;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out CarAheadMovement movement))
        {
            OnDied.Invoke(Score);
        }
    }
}