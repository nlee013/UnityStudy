using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Material backgroundMat;

    [Range(0, 1f)] public float moveSpeed = 0.2f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 dir = Vector2.up;
        backgroundMat.mainTextureOffset += dir * moveSpeed * Time.deltaTime;
    }
}
