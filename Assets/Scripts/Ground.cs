using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float maxX(GameObject obj)
    {
        return transform.position.x - transform.localScale.x / 2 + obj.transform.localScale.x;
    }
    public float maxZ(GameObject obj)
    {
        return transform.position.z - transform.localScale.z / 2 + obj.transform.localScale.z;
    }
}
