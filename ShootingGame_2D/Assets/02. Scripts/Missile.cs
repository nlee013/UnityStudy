using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    float MissileSpeed = 7f;

    void Start()
    {
        
    }

    void Update()
    {

        transform.Translate(Vector3.up * MissileSpeed * Time.deltaTime);
    }
}
