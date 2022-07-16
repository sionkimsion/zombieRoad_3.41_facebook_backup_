using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text meterText;
    public Text bestScore;
    float meter;
    public static GameManager gm;
    public bool isChaseShield = false;
    public bool stopEnemy = false;
    public bool gameOver = false;
    public bool highScore = false;
    private bool playAudio = true;
    public GameObject gameOverPNG, retry, bestScoreUI, gameOverUI;
    public Animator PlayerAnim;

    private AudioSource Audio;
    public AudioClip highScoreSound, gameOverSound;

    void Awake()
    {
        gm = this;
        Application.targetFrameRate =60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if(gm == null)
        {
            gm = this;
        } 
        else if (gm != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        initGame();
        bestScore.text = PlayerPrefs.GetFloat("bestScore", 0).ToString("N0").Replace(",", ""); 
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        meter += Time.deltaTime * 5;
        meterText.text = meter.ToString("N0").Replace(",", "");

        if (meter > PlayerPrefs.GetFloat("bestScore", 0)) {
            PlayerPrefs.SetFloat("bestScore", meter);
            bestScore.text = meter.ToString("N0").Replace(",", "");
            highScore = true;
        }

        if (gameOver) {
            gameOverPNG.SetActive(true);
            retry.SetActive(true);
            bestScoreUI.SetActive(true);
            gameOverUI.SetActive(true);
            PlayerAnim.SetBool("isDie", true);
            soundControl();
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

    void soundControl() {
        if (playAudio == false){
            return;
        }
        if (gameOver == true && highScore == true) {
            Audio.PlayOneShot(highScoreSound, 1F);
            playAudio=false;
        } else if (gameOver == true) {
            Audio.PlayOneShot(gameOverSound, 1F);
            playAudio=false;            
        }  
    }
}
