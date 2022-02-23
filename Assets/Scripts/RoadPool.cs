using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPool: MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private Road[] _roads;

    [SerializeField]
    private Road _firstRoad;

    private Road _currentRoad;
    private List<Road> spawnedRoads = new List<Road>();

    private void Start()
    {
        _currentRoad = _firstRoad;
        spawnedRoads.Add(_firstRoad);

        SpawnRoad(0);
        SpawnRoad(1);
        SpawnRoad(1);

    }

    private void Update()
    {
        if(_player.position.z > _currentRoad.GetFront().position.z - 60)
        {
            InsertRoad();
        }        
    }
    private void SpawnRoad(int i) {
        Road road = Instantiate(_roads[i]);
        road.transform.position = spawnedRoads[spawnedRoads.Count - 1].GetFront().position - road.GetBack().localPosition;
        spawnedRoads.Add(road);
        _currentRoad = road;

    }

    private void InsertRoad() {
        Road road;
        do
        {
            road = spawnedRoads[Random.Range(0, spawnedRoads.Count)];
        } while (_currentRoad.transform.position == road.transform.position);

        road.transform.position = _currentRoad.GetFront().position - road.GetBack().localPosition;
        _currentRoad = road;

    }

}
