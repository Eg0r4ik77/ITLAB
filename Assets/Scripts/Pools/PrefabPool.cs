using UnityEngine;

public abstract class PrefabPool : MonoBehaviour
{
    [SerializeField]
    protected Transform playerCar;

    protected readonly float distanceBetweenPlayerAndNewPrefab = 60f;

    protected abstract void Spawn();
    protected abstract int GetPrefabIndexForSpawn();
}
