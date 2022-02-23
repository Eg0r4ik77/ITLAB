using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 10f;
    private float _acceleration = 1.5f;

    private float _movementX;
    private float _movementZ;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _movementX = Input.GetAxis("Horizontal");
        _movementZ = Input.GetAxis("Vertical");
        transform.position += (new Vector3(_movementX, 0, 1) + (Vector3.forward * _movementZ) * _acceleration) * _speed * Time.deltaTime;
    }
}
