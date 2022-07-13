using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.SceneManagement;


public class MenuGameManager : MonoBehaviour
{
    public Animator anim;
    public GameObject start;

    void Awake()
    {
        Application.targetFrameRate =60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        FB.Init(InitCallback, OnHideUnity);
    }

    void Update()
    {
        Invoke("bloodAnim", 0.25f);
        Invoke("startImg", 0.3f);
        if ((Input.GetMouseButtonDown(0)) && start.activeSelf == true){
            SceneManager.LoadScene("MainScene");
        }
    }

    void bloodAnim ()
    {
        anim.SetBool("blood", true);
    }

    void startImg() 
    {
        start.SetActive(true);
    }

    private void InitCallback ()
    {
        if (FB.IsInitialized) {
            Debug.Log("Facebook SDK initialized");

            FB.ActivateApp();
        } else {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity (bool isGameShown)
    {
    } 
}
