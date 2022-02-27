using UnityEngine;

public class CarPrefab : MonoBehaviour
{
    public bool InUse{ get; private set; }

    public void SetUsage(bool inUse)
    {
        InUse = inUse;
    }
}
