using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class GarbagePool : Singleton<GarbagePool>
{
    public List<GameObject> garbageList = new List<GameObject>();
    private Ground _ground;
    private GameObject player;

    private void Awake()
    {
        _ground = FindObjectOfType<Ground>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        SetPositionGarbage();
        Restarter.Restart += Restarter_Restart;
    }

    private void Restarter_Restart(object sender, System.EventArgs e)
    {
        SetPositionGarbage();
    }

    private void SetPositionGarbage()
    {
        for (int i = 0; i < garbageList.Count-1; i++)
        {
            garbageList[i].transform.parent = gameObject.transform;
            garbageList[i].transform.position = RandomPos(garbageList[i]);
            garbageList[i].transform.rotation = randomRot();
        }   
    }
    private Vector3 RandomPos(GameObject garbage)
    {
        var xPos = _ground.maxX(garbage);
        var zPos = _ground.maxZ(garbage);

        //TODO : сделать отступ между мусором , и проверку на наличие свободного места
        Vector3 randomPos = new Vector3(Random.Range(-xPos, xPos), 0, Random.Range(-zPos, zPos));
        while (Vector3.Distance(player.transform.position, randomPos) < 1f)
            randomPos = new Vector3(Random.Range(-xPos, xPos), 0, Random.Range(-zPos, zPos));
        return randomPos;
    }
    private Quaternion randomRot()
    {
        var rot = Quaternion.Euler(0, Random.Range(0, 360), 0);
        return rot;
    }
    public int GetPickUpGarbageCount()
    {
        var i = 0;
        foreach (var item in garbageList)
        {
            if (item.GetComponent<ICanPickUp>() != null)
                i++;
        }
        return i;
    }
}
