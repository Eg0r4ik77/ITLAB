using UnityEngine;

public class PlayerCarMovement : CarMovement
{
    [SerializeField]
    Transform _leftBorder;
    
    [SerializeField]
    Transform _rightBorder;

    private readonly float _acceleration = 5f;

    private bool _isSpedUp;

    public PlayerCarMovement()
    {
        Speed = 15f;
    }

    public void Shift(float horizontal_offset, float accelerationState)
    {
        Vector3 resultDirection = rigidBody.position + (Speed * horizontal_offset * Vector3.right + accelerationState * _acceleration * Vector3.forward) * Time.deltaTime;
        resultDirection.x = Mathf.Clamp(resultDirection.x, _leftBorder.position.x, _rightBorder.position.x);
        rigidBody.MovePosition(resultDirection);
    }

    public void TrySetSpeedUp(bool isSpedUp)
    {
        if (_isSpedUp != isSpedUp)
        {
            _isSpedUp = isSpedUp;
            Speed = isSpedUp == true ? Speed + _acceleration : Speed - _acceleration;
        }
    }
}