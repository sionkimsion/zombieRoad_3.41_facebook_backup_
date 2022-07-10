using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_nMove : MonoBehaviour
{
    public ParticleSystem blood;
    public ParticleSystem bubble;
    private SpriteRenderer SR;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    private Color defaultColor;

    public Animator anim;

    void Awake()
    {
        SR = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default"); // or whatever sprite shader is being used
        defaultColor = SR.color;
    }

    void Update()
    {
        if (transform.position.x > 0) {
            SR.flipX = true;
        } else {
            SR.flipX = false;
        }
    }

    void FixedUpdate()
    {
        // 좌, 우 화면 밖으로 이동 시 사라짐.
        if (transform.position.x < -3.5f || transform.position.x > 3.5f) {
            Destroy(gameObject);
        }
            
        if (GameManager.gm.stopEnemy == true) {
            Vector3 stay = gameObject.transform.position;
            stay = gameObject.transform.position;
            anim.SetBool("freeze", true);
        } else {
            anim.SetBool("freeze", false);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "boom") {
            anim.SetBool("burn", true);
            Destroy(gameObject, 1f);
        }

        if (collision.gameObject.tag == "fireDrum") {
            anim.SetBool("burn", true);
            Destroy(gameObject, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "shield") {
            SR.color = Color.red;
            blood.transform.localScale = transform.localScale * 2.5f;
            Instantiate(blood, transform.position, transform.rotation);
        } else if (collision.gameObject.tag == "playerShield") {
            bubble.transform.localScale = transform.localScale * 2.5f;
            Instantiate(bubble, transform.position, transform.rotation);
        }

        if (collision.gameObject.tag == "Player") {
            SR.material.shader = shaderGUItext;
            SR.color = Color.red;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "shield") {
            SR.material.shader = shaderGUItext;
            SR.color = Color.white;
        }

        if (collision.gameObject.tag == "Player") {
            SR.material.shader = shaderGUItext;
            SR.color = Color.red;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            SR.material.shader = shaderGUItext;
            SR.color = Color.red;
        } else {
            SR.material.shader = shaderSpritesDefault;
            SR.color = defaultColor;
        }
    }
}
