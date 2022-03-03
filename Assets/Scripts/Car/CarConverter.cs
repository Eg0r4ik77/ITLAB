using UnityEngine;

public class CarConverter : MonoBehaviour
{
    [SerializeField]
    private CarPrefab[] _carPrefabs;

    public void ConvertCars(GameSpace gameSpace)
    {
        foreach(CarPrefab carPrefab in _carPrefabs)
        {
            ConvertCar(carPrefab.GetCarComponents(), gameSpace);
        }
    }

    private void ConvertCar(MeshRenderer[] carComponents, GameSpace gameSpace)
    {
        foreach(MeshRenderer carComponent in carComponents)
        {
            carComponent.enabled = gameSpace == GameSpace.Space2D ? false : true;
        }
    }
}
