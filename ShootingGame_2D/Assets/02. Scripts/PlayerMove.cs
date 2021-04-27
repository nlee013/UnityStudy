using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        // ¿Ãµø
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.up * v;

        transform.Translate(dir * speed * Time.deltaTime);
    }
}
