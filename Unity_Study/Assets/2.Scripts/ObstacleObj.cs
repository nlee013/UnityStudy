using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObj : MonoBehaviour
{
    [SerializeField] GameObject _prefabEffExplosion;
    [SerializeField] GameObject _prefabEffHit;

    int _limitDamge;

    void Start()
    {
        _limitDamge = 3;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        _limitDamge--;
        GameObject go = Instantiate(_prefabEffHit); // Hit 이펙트 
        go.transform.position = transform.position; // 위치 조정
        Destroy(go, 2);

        if(_limitDamge <= 0)
        {
            go = Instantiate(_prefabEffExplosion); // Hit 이펙트 
            go.transform.position = transform.position; // 위치 조정
            Destroy(go, 2);
            Destroy(gameObject, 1);
        }
    }
}
