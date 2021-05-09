using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<int> scores = new List<int>();


    //void Update()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        int randomNumer = Random.Range(0, 100);
    //        scores.Add(randomNumer);
    //    }

    //    if(Input.GetMouseButtonDown(1))
    //    {
    //        scores.RemoveAt(3);
    //    }
    //}

    private void Start()
    {
        //int score0 = 45;
        //int score1 = 20;
        //int score2 = 70;

        //scores.Add(score0);
        //scores.Add(score1);
        //scores.Add(score2);

        //scores.Remove(60);

        //Debug.Log(scores[1]);

        while(scores.Count > 0)
        {
            scores.RemoveAt(0);
        }

    }
}
