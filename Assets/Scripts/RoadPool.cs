using System.Collections.Generic;
using UnityEngine;

public class RoadPool: MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private Road[] _roads;
    [SerializeField] private Road _firstRoad;

    private Road _currentRoad;

    private void Start()
    {
        _currentRoad = _firstRoad;
    }

    private void Update()
    {
        if(_player.position.z > _currentRoad.GetFront().position.z - 60)
        {
            InsertRoad();
        }        
    }

    private void InsertRoad() {
        Road road;
        do
        {
            road = _roads[Random.Range(0,_roads.Length)];
        } while (_currentRoad.transform.position == road.transform.position);

        road.transform.position = _currentRoad.GetFront().position - road.GetBack().localPosition;
        _currentRoad = road;

    }

}
