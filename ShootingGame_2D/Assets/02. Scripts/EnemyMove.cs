using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float EnemySpeed = 5f;
    Vector3 dir;

    void Start()
    {
        // 방향변수
       

        // 랜덤 함수를 사용하여 0부터 9안에서 랜덤 int 값
        int Ran = Random.Range(0, 10);

        // 30퍼는 player쪽으로 이동
        if(Ran % 3 == 0)
        {
            // 플레이어를 찾기
            GameObject Target = GameObject.Find("Player");

            // 방향구하기 : 플레이어 방향 (Player포지션 - Enemy포지션) 방향벡터
            dir = Target.transform.position - transform.position;

            // 방향크기벡터 1로 만들기
            dir.Normalize();
        }
        else
        {
            // 나머지는 아래로
            dir = Vector3.down;
        }        
    }

    
    void Update()
    {
        transform.Translate(dir * EnemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);

        Destroy(gameObject);
    }
}
