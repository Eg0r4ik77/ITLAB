using UnityEngine;

[RequireComponent(typeof(CarAheadMovement))]
public class CarAheadPrefab : CarPrefab
{
    public bool InUse{ get; private set; }

    private CarAheadMovement _carAheadMovement;

    private void Awake()
    {
        _carAheadMovement = GetComponent<CarAheadMovement>();
    }

    public void SetUsage(bool inUse)
    {
        InUse = inUse;
    }

    public float GetMovementSpeed()
    {
        return _carAheadMovement.Speed;
    }

    public void SetMovementSpeed(float speed)
    {
        _carAheadMovement.Speed = speed;
    }
}
