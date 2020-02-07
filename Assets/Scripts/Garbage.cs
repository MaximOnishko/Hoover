using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Garbage : MonoBehaviour
{
    private void Awake()
    {
        GarbagePool.Instance.garbageList.Add(gameObject);
    }
}
