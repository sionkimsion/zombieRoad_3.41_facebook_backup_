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

        float y = Random.Range(-23f, 23f);
        gameObject.transform.position = new Vector3 (0, y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(0, offset);
    }
}
