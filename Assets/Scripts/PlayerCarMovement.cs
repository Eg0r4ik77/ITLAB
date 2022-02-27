using UnityEngine;

public class PlayerCarMovement : CarMovement
{
    [SerializeField]
    Transform _leftBorder;
    
    [SerializeField]
    Transform _rightBorder;

    private readonly float _acceleration = 5f;

    private void Start()
    {
        speed = 10f;
    }

    public void Shift(float horizontal_offset, float accelerationState)
    {
        Vector3 resultDirection = rigidBody.position + (speed * horizontal_offset * Vector3.right + accelerationState * _acceleration * Vector3.forward) * Time.deltaTime;
        resultDirection.x = Mathf.Clamp(resultDirection.x, _leftBorder.position.x, _rightBorder.position.x);
        rigidBody.MovePosition(resultDirection);
    }
}