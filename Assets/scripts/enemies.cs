using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour {
    public bool isChase = false;
    public ParticleSystem blood;
    public ParticleSystem bubble;

    GameObject player, shield;
    public float speed;

    private SpriteRenderer SR;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    public Animator anim;

    private Rigidbody2D RD;

    private Color defaultColor;

    void Awake()
    {
        RD = GetComponent<Rigidbody2D>();
        SR = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default"); // or whatever sprite shader is being used
        defaultColor = SR.color;
        
        player = GameObject.FindWithTag("Player");
        shield = GameObject.FindWithTag("shield");
    }

    void Start()
    {
        
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
        } else if (!GameManager.gm.stopEnemy) {
            anim.SetBool("freeze", false);
            // TriggerEnter 시 player 따라감.
            if (isChase) {
                anim.SetBool("run", true);
                Vector3 moveTo;
                if (GameManager.gm.isChaseShield == true) {
                    moveTo = shield.transform.position;
                    RD.position = Vector3.MoveTowards(RD.position, moveTo, speed * Time.deltaTime);
                } else {
                    moveTo = player.transform.position;
                    RD.position = Vector3.MoveTowards(RD.position, moveTo, speed * Time.deltaTime);   
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
            Destroy(gameObject, 1.0f);
        }
        
        if (collision.gameObject.tag == "fireDrum") {
            anim.SetBool("burn", true);
            Destroy(gameObject, 1.0f);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            isChase = true; 
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            isChase = false;
        }
    }

    // 깜빡이 효과
    void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.name == "shield") {
            SR.color = Color.red;
            blood.transform.localScale = transform.localScale * 2.5f;
            Instantiate(blood, transform.position, transform.rotation);
        } else if (collision.gameObject.tag == "Player") {
            SR.material.shader = shaderGUItext;
            SR.color = Color.red;
        } else if (collision.gameObject.tag == "playerShield") {
            bubble.transform.localScale = transform.localScale * 2.5f;
            Instantiate(bubble, transform.position, transform.rotation);
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
}
