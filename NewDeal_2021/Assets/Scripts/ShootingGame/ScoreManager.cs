using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0; 
    public int bestScore;
    public Text currentScoreTxt;
    public Text bestScoreTxt;

    private void Awake()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreTxt.text = "BestScore : " + bestScore;
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void SetScore(int value)
    {
        bestScoreTxt.text = "BestScore : " + bestScore;

        currentScore++;
        currentScoreTxt.text = "현재점수 : " + currentScore;

        bestScore = PlayerPrefs.GetInt("BestScore");

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        bestScoreTxt.text = "BestScore : " + bestScore;
    }

}
