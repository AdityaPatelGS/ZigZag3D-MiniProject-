using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject RoadPrefab;
    public float offset = 0.7071068f;
    public Vector3 lastPos;
    private int roadCount = 0;

    public int TurnChance;

    

    public void StartBuilding()
    {
        InvokeRepeating("createNewRoadPart", 0.2f, 0.2f);
    }

    public void createNewRoadPart()
    {
        Debug.Log("Create new road part");

        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);
        if(chance < 30)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }

        var g = Instantiate(RoadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));
        g.gameObject.tag = "Block";
        
        lastPos = g.transform.position;

        roadCount++;
        int RandomCrystalChance = Random.Range(0,10);
        if(RandomCrystalChance == 1)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
