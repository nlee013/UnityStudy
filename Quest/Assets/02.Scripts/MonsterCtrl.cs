using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    public enum MonsterState // 몬스터 상태정보가 있는 Enum
    {
        idle,
        trace,
        attack,
        die
    }

    // 몬스터의 현재 상태 정보를 저장 할 Enum 변수
    public MonsterState monsterState = MonsterState.idle; 

    // 속도 향상을 위해 각종 컴포넌트를 변수에 할당
    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator animator;
    private int hp = 100;

    public float traceDist = 6.0f; // 추적 사정거리
    public float attackDist = 2.0f; // 공격 사정거리
    public bool isDie = false; // 몬스터 사망 여부

    

    

    void Start()
    {
        monsterTr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // 추적대상의 위치를 설정하면 바로 추적 시작
        // nvAgent.destination = playerTr.position;

        StartCoroutine(this.CheckMonsterState()); // 일정 간격으로 몬스터의 행동 상태를 체크하는 코루틴 함수
        StartCoroutine(this.MonsterAction()); // 몬스터의 상태에 따라 동작하는 루틴을 실행
        
    }

    void Update()
    {
        nvAgent.destination = playerTr.position;
        animator.SetBool("IsTrace", true);
    }

    IEnumerator CheckMonsterState()
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.2f);

            // 몬스터와 플레이어 사이의 거리 측정
            float dist = Vector3.Distance(playerTr.position, monsterTr.position);

            if(dist <= attackDist && !FindObjectOfType<GameManger>().isGameOver) // 공격거리 범위 이내로 들어왔는지
            {
                monsterState = MonsterState.attack;
            }
            else if(dist <= traceDist)
            {
                monsterState = MonsterState.trace;
            }
            else
            {
                monsterState = MonsterState.idle;
            }
        }
    }

    IEnumerator MonsterAction()
    {
        while(!isDie)
        {
            switch(monsterState)
            {
                case MonsterState.idle: // idle 상태
                    nvAgent.isStopped = true;
                    animator.SetBool("IsTrace", false);
                    break;
                case MonsterState.trace: // 추적 상태
                    nvAgent.destination = playerTr.position;
                    nvAgent.isStopped = false;
                    animator.SetBool("IsAttack", false);
                    animator.SetBool("IsTrace", true);
                    break;
                case MonsterState.attack:
                    nvAgent.isStopped = true;
                    animator.SetBool("IsAttack", true);
                    break;
            }
            yield return null;
        }
    }

    public void GetDamage(float amounnt)
    {
        hp -= (int)(amounnt / 2.0f);
        animator.SetTrigger("IsHit");

        if(hp <=0)
        {
            MonsterDie();
        }
    }

    private void MonsterDie()
    {
        if (isDie == true)
            return;

        StopAllCoroutines();
        isDie = true;
        monsterState = MonsterState.die;
        nvAgent.isStopped = true;
        animator.SetTrigger("IsDie");

        gameObject.GetComponentInChildren<CapsuleCollider>().enabled = false;
        foreach (Collider coll in GetComponentsInChildren<CapsuleCollider>())
        {
            coll.enabled = false;
        }

        FindObjectOfType<GameManger>().GetScored(2);
    }
}
