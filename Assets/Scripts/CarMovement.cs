using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{
    [SerializeField] Transform _leftBorder;
    [SerializeField] Transform _rightBorder;

    private Rigidbody _rigidbody;
    
    private float _speed = 10f;
    private readonly float _acceleration = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(float horizontal_offset, float accelerationState)
    {
        Vector3 resultDirection = _rigidbody.position + (_speed * horizontal_offset * Vector3.right + (_speed + accelerationState * _acceleration) * Vector3.forward) * Time.deltaTime;
        resultDirection.x = Mathf.Clamp(resultDirection.x, _leftBorder.position.x, _rightBorder.position.x);
        _rigidbody.MovePosition(resultDirection);
    }
}
