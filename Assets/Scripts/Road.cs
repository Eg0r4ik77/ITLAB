using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Transform _back;
    [SerializeField] private Transform _front;

    public Transform GetBack()
    {
        return _back;
    }

    public Transform GetFront()
    {
        return _front;
    }
}
