using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnClickRetry()
    {
        Retry();
    }
}
