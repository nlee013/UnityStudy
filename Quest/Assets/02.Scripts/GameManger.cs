using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject playerGameoObject;
    public Text hpText;
    public Text scoreText;
    int score;
    public bool isGameOver;

    void Start()
    {
        score = 0;
        isGameOver = false;
    }

    void Update()
    {
        if(!isGameOver)
        {
            hpText.text = "HP :" + (int)playerGameoObject.GetComponent<PlayerController>().hp;
            scoreText.text = "Score :" + (int)score;
        }
    }

    public void GetScored(int value)
    {
        score += value;
    }
        
    public void EndGame()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
