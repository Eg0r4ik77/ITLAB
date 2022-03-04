using UnityEngine;

public class RoadPool: PrefabPool
{
    [SerializeField]
    private RoadPrefab[] _roads;

    [SerializeField]
    private RoadPrefab _firstRoad;

    [SerializeField]
    private RoadPrefab _specialRoad;

    private RoadPrefab _currentRoad;

    private float _specialRoadCoolDown = 30f;
    private float _lastTime;

    private void Start()
    {
        _currentRoad = _firstRoad;
    }

    private void Update()
    {
        if(playerCar.position.z > _currentRoad.Front.z - distanceBetweenPlayerAndNewPrefab)
        {
            if (_currentRoad == _specialRoad)
            {
                _lastTime = Time.time;
            }
            Spawn();
        }        
    }

    protected override void Spawn()
    {
        RoadPrefab road = Time.time - _lastTime > _specialRoadCoolDown ? _specialRoad : _roads[GetPrefabIndexForSpawn()];
        road.transform.position = _currentRoad.Front - road.LocalBack;
        _currentRoad = road;
    }

    protected override int GetPrefabIndexForSpawn()
    {
        int roadIndex;
        do
        {
            roadIndex = Random.Range(0, _roads.Length);
        } while (_currentRoad.transform.position == _roads[roadIndex].transform.position);

        return roadIndex;
    }
}
