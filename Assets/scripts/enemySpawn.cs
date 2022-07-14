using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject[] enemy;
    private GameObject[] spawnPoints;

    public float startTime;
    public float nextTime;
    public float destroyTime;

    float speed = 1.2f;


    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("enemyInMap");
        InvokeRepeating("SpawnEnemy", startTime, nextTime);
    }
    void SpawnEnemy()
    {
        GameObject spawnedObject;

        spawnedObject = Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity) as GameObject;

        Destroy(gameObject, destroyTime);
    }

    void Update() 
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
