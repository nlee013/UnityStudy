using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
   
    void Start()
    {
        Debug.Log("Dog의 총 개수 : " + Dog.count);
        Dog.ShowAnimalType();
    }

    void Update()
    {
        
    }
}
