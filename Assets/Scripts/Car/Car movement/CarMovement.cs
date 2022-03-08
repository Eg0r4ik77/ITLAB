using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{
    protected Rigidbody rigidBody;
    public float Speed { get; set; }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        PauseManager.Instance.OnPaused += SetPaused;
    }

    private void Update()
    {
        Move();
    }

    private void OnDestroy()
    {
        PauseManager.Instance.OnPaused -= SetPaused;
    }

    private void Move()
    {
        rigidBody.MovePosition(rigidBody.position + Speed * Time.deltaTime * Vector3.forward);
    }

    private void SetPaused(bool isPaused)
    {
        enabled = !isPaused;
    }
}
