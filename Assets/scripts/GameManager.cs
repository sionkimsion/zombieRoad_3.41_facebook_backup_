using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text meterText;
    float meter;
    public static GameManager gm;
    public bool isChaseShield = false;
    public bool stopEnemy = false;
    public bool gameOver = false;
    public GameObject gameOverPNG;
    public GameObject retry;
    public Animator PlayerAnim;

    void Awake()
    {
        gm = this;

        Application.targetFrameRate =60;
    }

    void Start()
    {
        initGame();
    }

    void Update()
    {
        meter += Time.deltaTime * 5;
        meterText.text = meter.ToString("N0");

        if (gameOver) {
            gameOverPNG.SetActive(true);
            retry.SetActive(true);
            PlayerAnim.SetBool("isDie", true);
            Invoke("dead", 0.1f);
        }
    }

    void initGame()
    {
        Time.timeScale = 1.0f;
    }
    void dead()
    {
        Time.timeScale = 0.0f;
    }
}
