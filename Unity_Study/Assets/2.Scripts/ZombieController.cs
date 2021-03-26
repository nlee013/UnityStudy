using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public enum eActionState
    {
        IDLE =0,
        WALK,
        RUN,
        ATTACK,
        HIT
    }

    [SerializeField] float _moveSpeed;
    [SerializeField] float _walkSpeed;
    
    eActionState _stateAction; // 현재 상태
    Animator _ctrlAni;
    Vector3 _posTarget;
    NavMeshAgent _navAgent;
    
    float _Speed; // 적용시킬 속도 저장할 변수
    bool _isDeath;
    bool _isAttack;


    private void Awake()
    {
        _isDeath = false;
        _isAttack = false;
        _ctrlAni = GetComponent<Animator>();
        _posTarget = transform.position;
        _navAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (_isDeath)
            return;

        if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int mask = 1 << LayerMask.NameToLayer("Floor");

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                // Debug.Log(hit.transform.gameObject.ToString() + " : " + hit.point.ToString());
                _posTarget = hit.point;
                transform.LookAt(_posTarget); // 타겟 바라보기
                ChangedAction(eActionState.WALK); // 애니메이션
                _navAgent.destination = _posTarget; // 목적지 넣어줌
            }
        }

        if(Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int mask = 1 << LayerMask.NameToLayer("Floor");

            if (Physics.Raycast(ray, out hit,Mathf.Infinity, mask))
            {
                // Debug.Log(hit.transform.gameObject.ToString() + " : " + hit.point.ToString());
                _posTarget = hit.point;
                transform.LookAt(_posTarget); // 타겟 바라보기
                ChangedAction(eActionState.RUN);
                _navAgent.destination = _posTarget;
            }
        }

        if (_isAttack)
            return;
        
        if(Vector3.Distance(transform.position, _posTarget) <= 0.1f) // 목적지에 도착하면
        {
            ChangedAction(eActionState.IDLE);
        }
        // transform.position = Vector3.MoveTowards(transform.position, _posTarget, Time.deltaTime * _Speed);
    }

    void ChangedAction(eActionState state)
    {
        switch(state)
        {
            case eActionState.WALK:
                if (_stateAction != eActionState.ATTACK)
                {
                    _navAgent.speed = _walkSpeed;
                    _stateAction = state;
                    _ctrlAni.SetInteger("AniState", (int)_stateAction);
                }                
                break;
            case eActionState.RUN:
                _navAgent.speed = _moveSpeed;
                _stateAction = state;
                _ctrlAni.SetInteger("AniState", (int)_stateAction);
                break;
            case eActionState.ATTACK:
                if(_stateAction == eActionState.RUN)
                {
                    _isAttack = true;
                    _stateAction = state;
                    _ctrlAni.SetInteger("AniState", (int)_stateAction);
                }
                _isAttack = true;
                break;
            case eActionState.HIT:
                _isDeath = true;
                _stateAction = state;
                _ctrlAni.SetInteger("AniState", (int)_stateAction);
                break;
        }

       
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 200, 80), "ATTACK"))
        {
            // _ctrlAni.SetInteger("AniState", (int)eActionState.ATTACK);
            ChangedAction(eActionState.ATTACK);
        }
        if (GUI.Button(new Rect(0, 85, 200, 80), "DEAD"))
        {
            // _ctrlAni.SetInteger("AniState", (int)eActionState.HIT);
            ChangedAction(eActionState.HIT);
        }
        //if (GUI.Button(new Rect(0, 170, 200, 80), "RUN"))
        //{
        //    _ctrlAni.SetInteger("AniState", (int)eActionState.RUN);
        //}
    }
}
