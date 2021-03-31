using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySceneManger : MonoBehaviour
{
    public enum eGameState
    {
        READY =0,
        START,
        PLAY,
        END,
        RESULT
    }

    [SerializeField] Image _helpBG;
    [SerializeField] Text _helpText;
    [SerializeField] Text _TimeText;

    eGameState _eState;
    float _timeCheck;
    float _timePass; // 시간 저장

    PlayerObj _pc;

    private void Awake()
    {
        _timeCheck = 0;
        _timePass = 60;
    }

    void Start()
    {
        _helpBG.enabled = false;
        _helpText.enabled = false;

        PrintTime(0);
        GameReady();
    }

    void Update()
    {
        switch(_eState)
        {
            case eGameState.START:
                _timeCheck += Time.deltaTime;
                
                if(_timeCheck >= 1.0f)
                {
                    GamePlay();
                }
                break;
            case eGameState.PLAY:
                //PrintTime(Time.deltaTime);
                if(_pc._ISDATH)
                {
                    GameEnd();
                }

                if(_timePass <= 0)
                {
                    GameEnd();
                }
                PrintTime(Time.deltaTime);
                break;
            case eGameState.END:
                _timeCheck += Time.deltaTime;

                if(_timeCheck >= 2.0f)
                {
                    GameResult();
                }
                break;
        }
    }

    void PrintTime(float deltaTime)
    {
        _timePass -= deltaTime;

        // 999:99 만들기
        int sec = (int)_timePass; // 초단위
        int msec = (int)((_timePass - sec) * 100); // 아래 소수점
        _TimeText.text = string.Format("{0}:{1}", sec, msec);
    }

    public void GameReady()
    {
        _eState = eGameState.READY;
        _helpBG.enabled = true;
        _helpText.enabled = true;

        _helpText.text = "READY!";
    }

    public void GameStart()
    {
        _eState = eGameState.START;
        _helpText.text = "Game Start!!";
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        _pc = go.GetComponent<PlayerObj>();
    }

    public void GamePlay()
    {
        _eState = eGameState.PLAY;
        _timeCheck = 0;
        _helpBG.enabled = false;
        _helpText.enabled = false;
    }

    public void GameEnd()
    {
        _eState = eGameState.END;
        _timePass = 0;
        _helpBG.enabled = true;
        _helpText.enabled = true;
        _helpText.text = "Game Over!!";
        _timeCheck = 0;
    }

    public void GameResult()
    {
        _eState = eGameState.RESULT;
        _helpBG.enabled = false;
        _helpText.enabled = false;

        ZombieController[] zombies = GameObject.FindObjectsOfType<ZombieController>(); // 좀비 다 가져오기
        for (int i = 0; i < zombies.Length; i++) // 전부 파괴
        {
            Destroy(zombies[i].gameObject);
        }
    }
}
