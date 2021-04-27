using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject missilePrefabs; // 미사일 프리팹
    public Transform firePosition; // 미사일 시작 위치

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }


    void Fire()
    {
        Instantiate(missilePrefabs, firePosition.position, Quaternion.identity);
    }


}
