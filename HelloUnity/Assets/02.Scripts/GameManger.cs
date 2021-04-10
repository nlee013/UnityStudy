using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject gameoverText;// 게임오버 패널
    public GameManger spawnerPrefabs; // 스포너 프리팹
    public Text timeText; // 생존 시간
    public Text recordText; //최고 기록할 변수
    

    private float surviveTime; // 생존시간
    private bool isGameover; // 게임오버

    [SerializeField] GameObject enemey;
    [SerializeField] Transform[] createEnemy;
    [SerializeField] float create_time;
    

    void Start()
    {
        InvokeRepeating("creat", 0, create_time);

        surviveTime = 0;
        isGameover = false;
       
    }

    void Update()
    {
        if(!isGameover) // 죽지 않았으면 시작 증가
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time:" + (int)surviveTime;
                        
            
        }
        else // 죽었으면 R 눌러서 다시 씬을 로드함
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time:" + (int)bestTime;
    }

    void creat()
    {
        int i = Random.Range(0, 8);

        Instantiate(enemey, createEnemy[i].position, createEnemy[i].rotation);


    }
}
