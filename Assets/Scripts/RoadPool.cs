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

    private List<Road> spawnedRoads = new List<Road>();

    private void Start()
    {
        spawnedRoads.Add(_firstRoad);
        SpawnRoad();
        SpawnRoad();
    }

    private void Update()
    {
        if(_player.position.z > spawnedRoads[spawnedRoads.Count - 1].GetFront().position.z - 60)
        {
            InsertRoad();
        }        
    }
    private void SpawnRoad() {
        Road road = Instantiate(_roads[Random.Range(0, _roads.Length - 1)]);
        road.transform.position = spawnedRoads[spawnedRoads.Count - 1].GetFront().position - road.GetBack().localPosition;
        spawnedRoads.Add(road);

    }

    private void InsertRoad() {
        Road road = spawnedRoads[0];
        spawnedRoads.Add(road);
        road.transform.position = spawnedRoads[spawnedRoads.Count - 1].GetFront().position - road.GetBack().localPosition;
        spawnedRoads.RemoveAt(0);
    }

}
