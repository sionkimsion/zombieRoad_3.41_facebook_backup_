using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_enemy : MonoBehaviour
{
    [SerializeField] GameObject enemy_origin;

    public int howMany;
    public float xPos, yPos;
    public float width, length;

    void Awake()
    {
        V_line(howMany); 
    }

    void Start()
    {
  
    }


    void V_line(int howMany)
    {
        

        // ���������� ����
        for (int i = 0; i < howMany; i ++) {
            Vector3 position = new Vector3(xPos + (i * width / 100f), yPos + (i * length / 10f), 0);
            Quaternion rotation = Quaternion.Euler(0, 0, 1 * 10);
            Instantiate(enemy_origin, transform.position + position, rotation);
        }

        // �������� ����
        for (int i = 0; i < howMany; i++) {
            Vector3 position = new Vector3(xPos - (i * width / 100f), yPos + (i * length / 10f), 0);
            Quaternion rotation = Quaternion.Euler(0, 0, 1 * 10);
            Instantiate(enemy_origin, transform.position + position, rotation);
        }
    }
}
