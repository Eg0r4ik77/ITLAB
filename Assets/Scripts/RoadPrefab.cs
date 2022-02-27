using UnityEngine;

public class RoadPrefab : MonoBehaviour
{
    [SerializeField]
    private Transform _back;
    
    [SerializeField]
    private Transform _front;

    public Vector3 Back => _back.position;
    public Vector3 Front => _front.position;
    public Vector3 LocalBack => _back.localPosition;
    public Vector3 LocalFront => _front.localPosition;
}
