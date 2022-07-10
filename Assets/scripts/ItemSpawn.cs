using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] items;
    private GameObject[] spawnPoints;
    int destroyTime = 17;

    

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("itemSpawn");
        Invoke("Spawnitem", 0);
    }
    void Spawnitem()
    {
        GameObject spawnedObject;

        // 아이템 확률
        int randNo = Random.Range(0, items.Length);
        if (randNo == 3 && Random.Range(0, 100) < 5) {
            return;
        }    

        spawnedObject = Instantiate(items[Random.Range(0, items.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity) as GameObject;

        Destroy(gameObject, destroyTime);
    }
}
