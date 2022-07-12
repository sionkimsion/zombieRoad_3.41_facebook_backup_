using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_cam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
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

    void OnPreCull() => GL.Clear(true, true, Color.black);

    // Update is called once per frame
    void Update()
    {
        
    }
}
