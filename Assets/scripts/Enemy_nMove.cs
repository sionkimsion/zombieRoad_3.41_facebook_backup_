using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_nMove : MonoBehaviour
{
    public bool isChase = false;
    public ParticleSystem blood;
    public ParticleSystem bubble;
    private SpriteRenderer SR;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    private Color defaultColor;

    public Animator anim;
    GameObject player, shield;
    private Rigidbody2D RD;
    public float speed;
    public float gravity;
    

    void Awake()
    {
        SR = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default"); // or whatever sprite shader is being used
        defaultColor = SR.color;
        shield = GameObject.FindWithTag("shield");
        RD = GetComponent<Rigidbody2D>();
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
            if (isChase){
                // 자석 아이템 사용시 쉴드 따라감.
                if (GameManager.gm.isChaseShield == true) {
                    Vector3 moveTo;
                    moveTo = shield.transform.position;
                    RD.position = Vector3.MoveTowards(RD.position, moveTo, speed * Time.deltaTime);
                } else {
                    Vector3 stay = gameObject.transform.position;
                    stay = gameObject.transform.position;  
                }
            }
            
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            isChase = true;
        } 

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
            SR.color = new Color(230/255f, 0, 0);
            blood.transform.localScale = transform.localScale * 2.5f;
            Instantiate(blood, transform.position, transform.rotation);    
        } else if (collision.gameObject.tag == "playerShield") {
            bubble.transform.localScale = transform.localScale * 2.5f;
            Instantiate(bubble, transform.position, transform.rotation);
        }

        if (collision.gameObject.tag == "Player") {
            SR.material.shader = shaderGUItext;
            SR.color = new Color(230/255f, 0, 0);
        } else {
            RD.gravityScale = gravity;
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
            SR.color = new Color(230/255f, 0, 0);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            SR.material.shader = shaderGUItext;
            SR.color = new Color(230/255f, 0, 0);
        } else {
            SR.material.shader = shaderSpritesDefault;
            SR.color = defaultColor;
        }
    }
}
