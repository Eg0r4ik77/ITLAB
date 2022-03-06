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

    private readonly float _specialRoadCoolDown = 30f;
    private float _lastTime;

    private void Awake()
    {
        PauseManager.Instance.OnPaused += SetPaused;
    }

    private void Start()
    {
        _currentRoad = _firstRoad;
    }

    private void Update()
    {
        _lastTime += Time.deltaTime;

        if(playerCar.position.z > _currentRoad.Front.z - distanceBetweenPlayerAndNewPrefab)
        {
            if (_currentRoad == _specialRoad)
            {
                _lastTime = 0;
            }
            Spawn();
        }        
    }

    private void OnDestroy()
    {
        PauseManager.Instance.OnPaused -= SetPaused;
    }

    protected override void Spawn()
    {
        RoadPrefab road =  _lastTime > _specialRoadCoolDown ? _specialRoad : _roads[GetPrefabIndexForSpawn()];
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

    private void SetPaused(bool isPaused)
    {
        enabled = !isPaused;
    }
}
