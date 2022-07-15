using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fence_Nmove : MonoBehaviour
{
    // public float gravity;

    void Start()
    {
       // gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
    }
    // destroy when fence with no movement trigger enemy_destroyer_bottom
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "enemy_destroyer_bottom") {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Destroy(gameObject);
        }
    }
}
