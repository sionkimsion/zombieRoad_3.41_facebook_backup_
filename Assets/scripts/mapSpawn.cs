using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> maps;

    private List<int> _pickedMaps = new();

    [SerializeField] private float speed;
    [SerializeField] private float countNum;

    private void Start()
    {
        StartCoroutine(GenerateMap());
    }

    private IEnumerator GenerateMap()
    {
        while (!(GameManager.gm.gameOver))
        {
            int count = maps.Count; // 맵의 갯수
            int idx;

            while (true) {
                idx = Random.Range(0, count);
                if (!_pickedMaps.Contains(idx)) break; // 같은 숫자 아닐 때까지 뽑기
            }

            _pickedMaps.Add(idx); // 뽑은 숫자 뽑은 리스트에 넣기
            Instantiate(maps[idx], transform.position, Quaternion.identity); // 해당 인덱스 맵 생성

            Debug.Log(maps[idx].name);
            yield return new WaitForSeconds(speed); // 17초

            // 일정 숫자 이상 뽑혔으면 뽑은 리스트 초기화 1/3이나 1/2 정도가 좋을듯
            if (_pickedMaps.Count == count ) _pickedMaps = new(); 
        }
    }
}
