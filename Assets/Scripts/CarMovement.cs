using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _speed = 10f;
    private readonly float _acceleration = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 horizontal_offset, float accelerationState)
    {
        Vector3 resultDirection = (horizontal_offset * _speed + Vector3.forward * (_speed + accelerationState*_acceleration)) * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + resultDirection);
    }
}
