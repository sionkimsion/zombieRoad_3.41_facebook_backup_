using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapSpawn : MonoBehaviour
{
    public GameObject[] enemies;
    private GameObject spawn;

    public float startTime;
    public float nextTime;

    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("enemySpawn");
        InvokeRepeating("SpawnEnemy", startTime, nextTime);
    }
    void SpawnEnemy()
    {
        GameObject spawnedObject;
        spawnedObject = Instantiate(enemies[Random.Range(0, enemies.Length)], spawn.transform.position, Quaternion.identity) as GameObject;

        Debug.Log(spawnedObject + "가 생성 되었습니다.");
    }
}
