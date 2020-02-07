using System;
using UnityEngine;


public class PlayerData : MonoBehaviour
{
    public static event EventHandler PlayerWin;

    public int currentGarbageCount
    {
        get
        {
            if (transform.childCount == GarbagePool.Instance.GetPickUpGarbageCount())
                PlayerWin?.Invoke(this, null);
            return transform.childCount;
        }
        private set { }
    }
    private void Start()
    {
        currentGarbageCount = 0;
    }
}
