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

    public event Action<bool> TransformedToAnotherSpace;
    private bool _isTurned = false;

    private void Awake()
    {
        _movement = GetComponent<PlayerCarMovement>();
        _transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        TransformedToAnotherSpace += _camera.OnTransformed;
        TransformedToAnotherSpace += _carConverter.ConvertCars;
    }

    private void OnDisable()
    {
        TransformedToAnotherSpace -= _camera.OnTransformed;
        TransformedToAnotherSpace -= _carConverter.ConvertCars;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       _movement.Shift(horizontal, vertical);

        float distance1 = _transform.position.z - _specialRoad.Back.z;
        if (distance1 > 0 && distance1 < 1 && !_isTurned)
        {
            _isTurned = true;
            TransformedToAnotherSpace?.Invoke(false);
        }

        float distance2 = _specialRoad.Front.z - _transform.position.z;
        if (distance2 > 0 && distance2 < 1 && _isTurned)
        {
            _isTurned = false;
            TransformedToAnotherSpace?.Invoke(true);
        }
    }
}
