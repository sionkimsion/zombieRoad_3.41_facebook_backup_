using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_scroll : MonoBehaviour
{
    private MeshRenderer render;
    private float offset;
    public float speed;
    
    void Start()
    {
        render = GetComponent<MeshRenderer>();

        float y = Random.Range(-20f, 20f);
        gameObject.transform.position = new Vector3 (0, y, transform.position.z);
    }

    void Update()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(0, offset);
    }
}
