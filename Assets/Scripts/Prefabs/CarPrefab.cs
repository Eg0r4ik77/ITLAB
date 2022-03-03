using UnityEngine;

public class CarPrefab : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer[] _carComponents;

    public MeshRenderer[] GetCarComponents()
    {
        return _carComponents;
    }
}
