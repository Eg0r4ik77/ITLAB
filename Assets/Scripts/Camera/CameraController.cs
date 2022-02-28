using UnityEngine;

[RequireComponent(typeof(CameraMovement))]
public class CameraController : MonoBehaviour
{
    private CameraMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<CameraMovement>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(_movement.SwitchTo2D());
        }
    }
}
