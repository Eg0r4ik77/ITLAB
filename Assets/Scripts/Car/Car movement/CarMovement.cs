using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{

    protected Rigidbody rigidBody;
    protected float speed;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        PauseManager.Instance.OnPaused += SetPause;
    }

    private void Update()
    {
        Move();
    }

    private void OnDestroy()
    {
        PauseManager.Instance.OnPaused -= SetPause;
    }

    private void Move()
    {
        rigidBody.MovePosition(rigidBody.position + speed * Time.deltaTime * Vector3.forward);
    }

    private void SetPause(bool isPaused)
    {
        enabled = !isPaused;
    }
}
