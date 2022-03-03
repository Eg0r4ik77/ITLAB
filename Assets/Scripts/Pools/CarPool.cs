using UnityEngine;

public class CarPool : PrefabPool
{
    [SerializeField]
    private CarAheadPrefab[] _cars;

    [SerializeField]
    private Transform _leftBorder;

    [SerializeField]
    private Transform _rightBorder;

    [SerializeField]
    private float _cooldown;

    private float _carWith;
    private float _lastTime;
    private int _carsInUseCount;

    private void Awake()
    {
        _carWith = _cars[0].GetComponent<BoxCollider>().size.x;
    }

    private void Update()
    {
        if(_carsInUseCount < _cars.Length  && Time.time - _lastTime > _cooldown)
        {
            Spawn();
        }

        ResetUsedCars();
    }

    protected override void Spawn()
    {
        CarAheadPrefab car = _cars[GetPrefabIndexForSpawn()];

        Vector3 spawnPlace = new Vector3(Random.Range(_leftBorder.position.x + _carWith / 2, _rightBorder.position.x - _carWith / 2), playerCar.position.y, playerCar.position.z + distanceBetweenPlayerAndNewPrefab);
        car.transform.position = spawnPlace;

        UpdateSpawnParameters(car);
    }

    protected override int GetPrefabIndexForSpawn()
    {
        int carIndex;
        do
        {
            carIndex = Random.Range(0, _cars.Length);
        } while (_cars[carIndex].InUse);

        return carIndex;
    }

    private void UpdateSpawnParameters(CarAheadPrefab spawnedCar)
    {
        spawnedCar.SetUsage(true);
        _lastTime = Time.time;
        _cooldown = Random.Range(2f, 4f);
        _carsInUseCount++;
    }

    private void ResetUsedCars()
    {
        foreach(CarAheadPrefab car in _cars)
        {
            if (car.InUse && playerCar.position.z - car.transform.position.z > distanceBetweenPlayerAndNewPrefab)
            {
                car.SetUsage(false);
                _carsInUseCount--;
            }
        }
    }
}