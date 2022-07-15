using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
    public float speed;
    // public GameObject rink;

    void Awake()
    {
        // 9:16 비율에 맞게 자르기
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)9 / 19); // (가로 / 세로)
        float scalewidth = 1f / scaleheight;
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
    }

    /* void Start () {
        // 좌우에 맞게 카메라 줌
        Camera.main.orthographicSize = rink.transform.localScale.x * Screen.height / Screen.width * 0.5f; 
	} */

    void OnPreCull() => GL.Clear(true, true, Color.black);

    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0); 
        if (GameManager.gm.gameOver == true){
            GetComponent<AudioSource>().volume = 0;            
        }  
    }
}
