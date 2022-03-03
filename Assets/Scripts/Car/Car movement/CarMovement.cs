using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{
    protected Rigidbody rigidBody;

    protected float speed;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rigidBody.MovePosition(rigidBody.position + speed * Time.deltaTime * Vector3.forward);
    }
}
