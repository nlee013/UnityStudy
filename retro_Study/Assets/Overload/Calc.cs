using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calc : MonoBehaviour
{
    public int Sum(int a, int b)
    {
        return a + b;
    }

    void Start()
    {
        Debug.Log(Sum(1,1));
        Debug.Log(Sum(1, 1, 1));
        Debug.Log(Sum(1.5f, 1.5f));
    }

    public int Sum(int a, int b, int c)
    {
        return a + b + c;
    }

    public float Sum(float a, float b)
    {
        return a + b;
    }

}
