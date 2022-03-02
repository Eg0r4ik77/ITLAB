using System;
using UnityEngine;

[RequireComponent(typeof(PlayerCarMovement))]
[RequireComponent(typeof(Transform))]
public class PlayerController : MonoBehaviour
{
    private PlayerCarMovement _movement;
    private Transform _transform;

    [SerializeField]
    private CameraController _camera;

    [SerializeField]
    private RoadPrefab _specialRoad;

    public event Action TransformedTo2D;    
    public event Action TransformedTo3D;

    private void Awake()
    {
        _movement = GetComponent<PlayerCarMovement>();
        _transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        TransformedTo2D += _camera.OnTransformedTo2D;
        TransformedTo3D += _camera.OnTransformedTo3D;
    }

    private void OnDisable()
    {
        TransformedTo2D -= _camera.OnTransformedTo2D;
        TransformedTo3D -= _camera.OnTransformedTo3D;
    }

    bool isTurned = false;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       _movement.Shift(horizontal, vertical);

        float distance1 = _transform.position.z - _specialRoad.Back.z;
        if (distance1 > 0 && distance1 < 1 && !isTurned)
        {
            isTurned = true;
            TransformedTo2D?.Invoke();
        }

        float distance2 = _specialRoad.Front.z - _transform.position.z;
        if (distance2 > 0 && distance2 < 1 && isTurned)
        {
            isTurned = false;
            TransformedTo3D?.Invoke();
        }
    }
}
