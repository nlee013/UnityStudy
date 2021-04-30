using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    string tempA = "NewDeal";
    string tempB = "Deal";
    void Start()
    {
        
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            string middleword = PickMiddleWords(tempA);
            print(middleword);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            string middleword = PickMiddleWords(tempB);
            print(middleword);
        }
    }

    string PickMiddleWords(string word)
    {
        string middleword = "";
        int Half = word.Length / 2;

        if(word.Length % 2 ==0)
        {
            middleword = string.Format("{0},{1}", word[Half - 1], word[Half]);
        }
        else
        {
            middleword += word[Half];
        }

        return middleword;
    }
}
