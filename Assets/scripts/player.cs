using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // public int speed = 1;
    public GameObject gameOverPNG;
    public GameObject retry;
    public Animator anim;

    void Update()
    {
        // transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "enemyFence" || collision.gameObject.tag == "fireDrum") {
            if (!(collision.gameObject.tag == "enemy" &&
                collision.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("burn"))) {
                GameManager.gm.gameOver = true;
            }
        } 
     }
}
