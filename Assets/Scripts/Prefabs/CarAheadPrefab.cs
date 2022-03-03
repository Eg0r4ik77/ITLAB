using UnityEngine;

public class CarAheadPrefab : CarPrefab
{
    public bool InUse{ get; private set; }

    public void SetUsage(bool inUse)
    {
        InUse = inUse;
    }
}
