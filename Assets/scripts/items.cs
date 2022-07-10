using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    bool isChase = false;
    public float speed = 2;

    void Update()
    {
        if (isChase) {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("shield").transform.position, speed * Time.deltaTime);
        } 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "shield") {
            isChase = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shield") {
            Destroy(gameObject);
        }
    }
}
