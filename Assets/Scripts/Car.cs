using UnityEngine;

[RequireComponent(typeof(CarMovement))]
public class Car : MonoBehaviour
{
    private CarMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<CarMovement>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       _movement.Move(new Vector3(horizontal, 0, 0), vertical);
    }

}
