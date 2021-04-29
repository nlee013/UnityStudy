using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwner : MonoBehaviour
{
    float currentTime = 0;

    [SerializeField] float apperTime = 1;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float minTime = 1;
    [SerializeField] float maxTime = 5;

    private void Start()
    {
        apperTime = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > apperTime)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = transform.position; 
            currentTime = 0;

            // 적이 생성후 적 생성 시간 다시 설정
            apperTime = Random.Range(minTime, maxTime);
        }        
    }



    //[SerializeField] private GameObject EnemyPrefab;
    //[SerializeField] private float minSpawnTime = 1.0f;
    //[SerializeField] private float maxSpawnTime = 3.5f;


    //private void Start()
    //{
    //    StartCoroutine("EnemySpawn");
    //}

    //private IEnumerator EnemySpawn()
    //{
    //    GameObject 

    //    float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    //    yield return new WaitForSeconds(spawnTime);
    //}

}

