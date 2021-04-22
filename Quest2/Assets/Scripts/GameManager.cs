using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject playerGameObject;
    public Text hpText;
    public Text scoreText;
    int score;
    public bool isGameOver;

    MovementProvider moveProvider;
    AudioSource musicSource;
    public GameObject Desk;
    public GameObject LittleBall;
   
    void Start()
    {
        score = 0;
        isGameOver = false;
        moveProvider = GetComponent<MovementProvider>();
        musicSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        Desk.SetActive(false);
        LittleBall.SetActive(false);
        moveProvider.StartMove(); // 이동을 시작!
        musicSource.Play();
    }
    void Update()
    {
        if(!isGameOver)
        {
            hpText.text = "HP :" + (int)playerGameObject.GetComponent<PlayerController>().hp;
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
