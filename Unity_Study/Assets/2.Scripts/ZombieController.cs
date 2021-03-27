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

    public enum eCharacter
    {
        Fierce =0,
        lazy
    }

    [SerializeField] float _moveSpeed;
    [SerializeField] float _walkSpeed;
    [SerializeField] BoxCollider _damageZone;
    [SerializeField] float _limitX = 5;
    [SerializeField] float _limitZ = 5;
    [SerializeField] float _minTime = 2;
    [SerializeField] float _MaxTime = 7;
    [SerializeField] eCharacter _eCh;
    
    eActionState _stateAction; // 현재 상태
    Animator _ctrlAni;
    Vector3 _posTarget;
    Vector3 _startPos; // 발판 중심
    NavMeshAgent _navAgent;
    
    float _Speed; // 적용시킬 속도 저장할 변수
    bool _isDeath;
    bool _isAttack;
    float _timeWait;
    bool _isSelectAi;
    int _characterStd;
    bool _isBattle;
    


    private void Awake()
    {
        _isDeath = false;
        _isAttack = false;
        _ctrlAni = GetComponent<Animator>();
        _startPos = _posTarget = transform.position;
        _navAgent = GetComponent<NavMeshAgent>();
        _timeWait = 0;
        _isSelectAi = false;
        _characterStd = 0;
        _isBattle = false;
    }

    private void Start()
    {
        switch (_eCh)
        {
            case eCharacter.Fierce:
                _characterStd = 25;
                break;
            case eCharacter.lazy:
                _characterStd = 80;
                break;
        }
    }

    private void Update()
    {
        if (_isDeath)
            return;


        switch (_stateAction)
        {
            
            case eActionState.IDLE: // 멈춰있을때
                _timeWait -= Time.deltaTime;
                if(_timeWait <= 0) // 시간이 0초가 되거나
                {
                    _isSelectAi = false;
                }
                break;

            case eActionState.WALK: // 목적지에 도착하면
                if (Vector3.Distance(_posTarget, transform.position) <= 0.1f)
                {
                    _isSelectAi = false;
                }
                break;

            case eActionState.RUN:
                if(Vector3.Distance(_posTarget, transform.position) <= 3.1f)
                {
                    ChangedAction(eActionState.ATTACK);
                }
                else
                {
                    ChangedAction(eActionState.RUN);
                }
                break;

            case eActionState.ATTACK:
                break;
        }

        ProcessAI();
    }

    void ProcessAI()
    {
        if(!_isSelectAi) // ai선택이 false면
        {
            int r = Random.Range(0, 100);

            if(r < _characterStd) // 대기
            {
                ChangedAction(eActionState.IDLE);
                _timeWait = Random.Range(_minTime, _MaxTime);
                Debug.Log("A");
            }
            else // 걷기
            {
                ChangedAction(eActionState.WALK);
                _posTarget = GetRandomPos(_startPos, _limitX, _limitZ);
                _navAgent.destination = _posTarget;
                Debug.Log("B");
            }
            _isSelectAi = true;
            Debug.Log(r);
        }       
    }

    Vector3 GetRandomPos(Vector3 center, float limitX, float limitZ)
    {
        float rX = Random.Range(-limitX, limitX);
        float rZ = Random.Range(-limitZ, limitZ);

        Vector3 rv = new Vector3(rX, 0, rZ);
        return center + rv;
    }

    // ============== 네비게이션 연습 ====================
    //void Update()
    //{
    //    if (_isDeath)
    //        return;

    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        int mask = 1 << LayerMask.NameToLayer("Floor");

    //        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
    //        {
    //            // Debug.Log(hit.transform.gameObject.ToString() + " : " + hit.point.ToString());
    //            _posTarget = hit.point;
    //            transform.LookAt(_posTarget); // 타겟 바라보기
    //            ChangedAction(eActionState.WALK); // 애니메이션
    //            _navAgent.destination = _posTarget; // 목적지 넣어줌
    //        }
    //    }

    //    if (Input.GetButtonDown("Fire2"))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        int mask = 1 << LayerMask.NameToLayer("Floor");

    //        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
    //        {
    //            // Debug.Log(hit.transform.gameObject.ToString() + " : " + hit.point.ToString());
    //            _posTarget = hit.point;
    //            transform.LookAt(_posTarget); // 타겟 바라보기
    //            ChangedAction(eActionState.RUN);
    //            _navAgent.destination = _posTarget;
    //        }
    //    }

    //    if (_isAttack)
    //        return;

    //    if (Vector3.Distance(transform.position, _posTarget) <= 0.1f) // 목적지에 도착하면
    //    {
    //        ChangedAction(eActionState.IDLE);
    //    }
    //    // transform.position = Vector3.MoveTowards(transform.position, _posTarget, Time.deltaTime * _Speed);
    //}

    void ChangedAction(eActionState state)
    {
        switch(state)
        {
            case eActionState.IDLE:
                _stateAction = state;
                _ctrlAni.SetInteger("AniState", (int)_stateAction);
                break;
            case eActionState.WALK:
                if (_stateAction != eActionState.ATTACK)
                {
                    _navAgent.speed = _walkSpeed;
                    _navAgent.stoppingDistance = 0;
                    _stateAction = state;
                    _ctrlAni.SetInteger("AniState", (int)_stateAction);
                }                
                break;
            case eActionState.RUN:
                _navAgent.speed = _moveSpeed;
                _navAgent.stoppingDistance = 3;
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

    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(0, 0, 200, 80), "ATTACK"))
    //    {
    //        // _ctrlAni.SetInteger("AniState", (int)eActionState.ATTACK);
    //        ChangedAction(eActionState.ATTACK);
    //    }
    //    if (GUI.Button(new Rect(0, 85, 200, 80), "DEAD"))
    //    {
    //        // _ctrlAni.SetInteger("AniState", (int)eActionState.HIT);
    //        ChangedAction(eActionState.HIT);
    //    }
    //    //if (GUI.Button(new Rect(0, 170, 200, 80), "RUN"))
    //    //{
    //    //    _ctrlAni.SetInteger("AniState", (int)eActionState.RUN);
    //    //}
    //}

    private void DamageOn()
    {
        _damageZone.enabled = true;
    }

    private void DamageOff()
    {
        _damageZone.enabled = false;
    }

    private void OnMouseDown()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // 플레이어 찾아오기
        _isBattle = true;
        ChangedAction(eActionState.RUN);
        _posTarget = player.transform.position;
        _navAgent.destination = _posTarget;
    }
}
