
using UnityEngine;
using System;

public class Restarter : MonoBehaviour
{
    public static event EventHandler Restart;

    public void ResetLevel()
    {
        Restart?.Invoke(this, null);
    }
}
