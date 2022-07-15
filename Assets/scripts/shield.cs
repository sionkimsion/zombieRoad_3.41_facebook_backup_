using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class shield : MonoBehaviour
{
    public camera_move mainCam;
    public GameObject playerShield, boom;
    public Animator anim;

    public ParticleSystem ice;

    Vector3 curPos;
    Vector3 newPos;
    
    private Rigidbody2D RD;
    private SpriteRenderer SR;
    private Color defaultColor;

    public float itemTime = 5.0f;

    private AudioSource Audio;
    public AudioClip followShieldSound, stopEnemySound, powerUpSound, bigShieldSound, bloodSound;
   
    void Awake()
    {
        RD = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        Audio = GetComponent<AudioSource>();
        defaultColor = SR.color;
    }


    void Update()
    {
        // && !EventSystem.current.IsPointerOverGameObject()

        if (Input.GetMouseButtonDown(0) && !GameManager.gm.gameOver) {
            newPos = curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0) && !GameManager.gm.gameOver) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            curPos = mousePosition;

            newPos = new Vector3(newPos.x, newPos.y + mainCam.speed * Time.deltaTime, newPos.z);
            Vector3 gap = curPos - newPos;
            gameObject.transform.localPosition += gap;
            newPos = curPos;   
        } 

        // 화면 밖으로 나가는 것을 방지
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //제한한 좌표 값을 플레이어의 월드좌표에 반영한다.
        transform.position = worldPos; //좌표를 적용한다.
    }

    void bigShieldOff()
    {
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0);
    }

    void strongerOff()
    {
        gameObject.GetComponent<PointEffector2D>().forceMagnitude = 25;
        anim.SetBool("powerUp", false);
    }

    void playerShieldOff()
    {
        playerShield.SetActive(false);
    }

    void followShieldOff()
    {
        GameManager.gm.isChaseShield = false;
        anim.SetBool("followShield", false);
    }

    void boomerOff()
    {
        boom.SetActive(false);
    }

    void stopEnemy()
    {
        GameManager.gm.stopEnemy = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy") {
            Audio.PlayOneShot(bloodSound, 0.8F);
        }

        if (collision.gameObject.tag == "bigShield") {
            gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0);
            Audio.PlayOneShot(bigShieldSound, 1.2F);
            Invoke("bigShieldOff", itemTime);
        } 
        else if (collision.gameObject.tag == "stronger") {
            gameObject.GetComponent<PointEffector2D>().forceMagnitude = 75;
            anim.SetBool("powerUp", true);
            Audio.PlayOneShot(powerUpSound, 1.2F);
            Invoke("strongerOff", itemTime);
        } 
        else if (collision.gameObject.tag == "playerShield") {
            playerShield.SetActive(true);
            Invoke("playerShieldOff", itemTime);
        } 
        else if (collision.gameObject.tag == "boomer") {
            boom.SetActive(true); 
            Invoke("boomerOff", 2f);
        }
        else if (collision.gameObject.tag == "followShield") {
            GameManager.gm.isChaseShield = true;
            anim.SetBool("followShield", true);
            Audio.PlayOneShot(followShieldSound, 1.2F);
            Invoke("followShieldOff", itemTime);
        }
        else if (collision.gameObject.tag=="stopEnemy") {
            GameManager.gm.stopEnemy = true;
            Audio.PlayOneShot(stopEnemySound, 1.2F);
            Invoke("stopEnemy", itemTime);
        }
    }
}