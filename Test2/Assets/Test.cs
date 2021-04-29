using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Renderer cubeColor;

    void Start()
    {
        cubeColor = gameObject.GetComponent<Renderer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cubeColor.material.color != Color.red)
            {
                cubeColor.material.color = Color.red;
                transform.localScale = Vector3.one * 5;
            }
            else
            {
                cubeColor.material.color = Color.blue;
                transform.localScale = Vector3.one * 10;
            }
        }

        transform.Rotate(new Vector3(10f, 20f, 30f) * Time.deltaTime, Space.World);
    }

}
