using UnityEngine;

[RequireComponent(typeof(PlayerCarMovement))]
public class PlayerController : MonoBehaviour
{
    private PlayerCarMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerCarMovement>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       _movement.Shift(horizontal, vertical);
    }
}
