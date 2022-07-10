using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireDrum : MonoBehaviour
{
    private SpriteRenderer SR;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    private Color defaultColor;
    public Animator anim;
    private Rigidbody2D RD;

    void Awake()
    {
        RD = GetComponent<Rigidbody2D>();
        SR = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default"); // or whatever sprite shader is being used
        defaultColor = SR.color;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "shield") {
            SR.material.shader = shaderGUItext;
            SR.color = Color.white;
        } else if (collision.gameObject.tag == "Player") {
            SR.material.shader = shaderGUItext;
            SR.color = Color.red;
        } else if (!(collision.gameObject.tag == "shield")) {
            anim.SetBool("boom", true);
            Destroy(gameObject, 0.5f);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "shield") {
            SR.material.shader = shaderGUItext;
            SR.color = Color.white;
        } else if (collision.gameObject.tag == "Player") {
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.tag == "shield")) {
            RD.rotation = 0;
        }

        if (collision.gameObject.tag == "fireDrum") {
            anim.SetBool("boom", true);
            Destroy(gameObject, 0.5f);
        }
    }
}
