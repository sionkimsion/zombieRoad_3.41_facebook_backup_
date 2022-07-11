using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_menu : MonoBehaviour
{
    private MeshRenderer render;
    private float offset;
    public float speed;
    
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(0, offset);
    }
}
