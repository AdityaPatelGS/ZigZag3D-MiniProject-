using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject RoadPrefab;
    public float offset = 0.7071068f;
    public Vector3 lastPos;
    private int roadCount = 0;

    public void StartBuilding()
    {
        InvokeRepeating("createNewRoadPart", 0.02f, 0.02f);
    }

    public void createNewRoadPart()
    {
        //Debug.Log("Create new road part");

        Vector3 spawnPos = Vector3.zero;

        if(roadCount <50)
        {
            float chance = Random.Range(0, 100);
            if (chance < 30)
            {
                spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
            }
            else
            {
                spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
            }
            

        }
        else if(roadCount <100) 
        {
            float chance = Random.Range(0, 100);
            if (chance < 60)
            {
                spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
            }
            else
            {
                spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
            }
        }
        else
        {
            float chance = Random.Range(0, 100);
            if (chance < 80)
            {
                spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
            }
            else
            {
                spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
            }
        }

        var g = Instantiate(RoadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));
        g.gameObject.tag = "Road";
        lastPos = g.transform.position;
        roadCount++;


        if (roadCount > 50)
        {
            int RandomBlankChance = Random.Range(0, 10);    
            if(RandomBlankChance ==1)
            {
                g.gameObject.SetActive(false);
            }
        }
        else if (roadCount > 100)
        {
            int RandomBlankChance = Random.Range(0, 10);
            if (RandomBlankChance < 5)
            {
                g.gameObject.SetActive(false);
            }
        }

        int RandomCrystalChance = Random.Range(0,10);
        if(RandomCrystalChance == 1)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
