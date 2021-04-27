using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNumArr : MonoBehaviour
{
    public int[] numer = { 0, 1, 2, 3, 4 };
    int temp;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeNumAr(0, 2);

            for (int i = 0; i < numer.Length; i++)
            {
                print(numer[i]);
            }
        }          
    }

    private void ChangeNumAr(int i, int j)
    {

        temp = numer[i];
        numer[i] = numer[j];
        numer[j] = temp;

    }
}
