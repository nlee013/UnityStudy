using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTest : MonoBehaviour
{
    private int colorNum = 1;
    Renderer mat;

    private void Start()
    {
        mat = GetComponent<Renderer>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchColor();
        }

    }

    void SwitchColor()
    {
        switch (colorNum)
        {
            case 1:
                mat.material.color = Color.red;
                break;
            case 2:
                mat.material.color = Color.green;
                break;
            case 3:
                mat.material.color = Color.blue;
                break;
            case 4:
                mat.material.color = Color.black;
                break;

        }
        colorNum++;
        if (colorNum > 6)
        {
            colorNum -= 7;
        }
    }

}
