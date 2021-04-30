using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public int[] numArr = new int[46];

    void Start()
    {
        for (int i = 0; i < numArr.Length; i++)
        {
            numArr[i] = i;
        }       

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeAllNumArr();

            string allNum = "";

            for (int i = 0; i < numArr.Length; i++)
            {
                allNum = allNum + numArr[i];
                allNum = allNum + " ";
            }

            print(allNum);
        }
    }

    void ChangeAllNumArr()
    {
        
    }
}
