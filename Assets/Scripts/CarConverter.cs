using UnityEngine;

public class CarConverter : MonoBehaviour
{
    [SerializeField]
    private CarPrefab[] _carPrefabs;

    public void ConvertCars(bool is2D)
    {
        foreach(CarPrefab carPrefab in _carPrefabs)
        {
            ConvertCar(carPrefab.GetCarComponents(), is2D);
        }
    }

    private void ConvertCar(MeshRenderer[] carComponents, bool is2D)
    {
        foreach(MeshRenderer carComponent in carComponents)
        {
            carComponent.enabled = is2D;
        }
    }
}
