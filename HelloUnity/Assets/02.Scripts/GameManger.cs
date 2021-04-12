using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject gameoverText;// 게임오버 패널
    public GameObject spawnerPrefabs; // 스포너 프리팹
    public Text timeText; // 생존 시간
    public Text recordText; //최고 기록할 변수
    

    private float surviveTime; // 생존시간
    private bool isGameover; // 게임오버

    public GameObject level; // 블렛등 레벨 수정할 변수
    public GameObject bullerSpawnerPrefab;
    Vector3[] bulletSpawners = new Vector3[4];
    int spawnCounter = 0;

    //[SerializeField] GameObject enemey;
    //[SerializeField] Transform[] createEnemy;
    //[SerializeField] float create_time;


    void Start()
    {
        //InvokeRepeating("creat", 0, create_time);

        surviveTime = 0;
        isGameover = false;

       // 배열에 값 지정
        bulletSpawners[0].x = -8f;
        bulletSpawners[0].y = 1f;
        bulletSpawners[0].z = 8f;

        bulletSpawners[1].x = 8f;
        bulletSpawners[1].y = 1f;
        bulletSpawners[1].z = 8f;

        bulletSpawners[2].x = 8f;
        bulletSpawners[2].y = 1f;
        bulletSpawners[2].z = -8f;

        bulletSpawners[3].x = -8f;
        bulletSpawners[3].y = 1f;
        bulletSpawners[3].z = -8f;


    }

    void Update()
    {
        if(!isGameover) // 죽지 않았으면 시작 증가
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time:" + (int)surviveTime;

            if (surviveTime < 5f && spawnCounter == 0)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Roator>().rotationSpeed += 15;
                spawnCounter++;
            }
            else if (surviveTime >= 5f && surviveTime < 10f && spawnCounter == 1)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Roator>().rotationSpeed += 15;
                spawnCounter++;
            }
            else if (surviveTime >= 10f && surviveTime < 15f && spawnCounter == 2)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Roator>().rotationSpeed += 15;
                spawnCounter++;
            }
            else if (surviveTime >= 15f && surviveTime < 20f && spawnCounter == 3)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Roator>().rotationSpeed += 15;
                spawnCounter++;
            }

        }
        else // 죽었으면 R 눌러서 다시 씬을 로드함
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame() // 게임이 끝나면 점수 제어
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

    //void creat() // InvokeRepeating에 넣어줄 함수
    //{
    //    int i = Random.Range(0, 8);

    //    Instantiate(enemey, createEnemy[i].position, createEnemy[i].rotation);
    //}
}
