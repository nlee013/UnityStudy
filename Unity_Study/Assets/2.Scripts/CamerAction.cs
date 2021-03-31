using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerAction : MonoBehaviour
{
    public enum eCameraActionState
    {
        MoveWALK =0,
        PLAYERSEEKER
    }

    GameObject _MovePointRoot;
    List<Transform> _ltPoints;
    GameObject _player;
    Vector3 _offset; // 카메라 y값을 올려주기 위함
    PlaySceneManger _mngPlay;

    eCameraActionState _eCamState;

    int _index;
    float _Speed;
    

    private void Awake()
    {
        _ltPoints = new List<Transform>();
        _index = 0;
        _offset = new Vector3(0, 1.6f, 0);
        _eCamState = eCameraActionState.MoveWALK;

#if UNITY_EDITOR // 테스트용 전처리기
        _Speed = 30;
#else
        _Speed = 10;
#endif
    }

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("PlayManger");
        _mngPlay = go.GetComponent<PlaySceneManger>();

        _MovePointRoot = GameObject.FindGameObjectWithTag("CameraRoot");

        for (int i = 0; i < _MovePointRoot.transform.childCount; i++)
        {
            Transform tf = _MovePointRoot.transform.GetChild(i); // 자식을 가지고 옴
            _ltPoints.Add(tf); // 리스트에 넣어줌
        }

        transform.position = _ltPoints[_index].position;
        transform.LookAt(_MovePointRoot.transform);
        _index++;
    }

    void Update()
    {
        if(_eCamState == eCameraActionState.MoveWALK)
        {
            if (_index < _MovePointRoot.transform.childCount) // point를 다 세면 끝
            {
                // transform.position = Vector3.Lerp(transform.position, _ltPoints[_index].position, Time.deltaTime); // 보간 카메라 워크
                transform.position = Vector3.MoveTowards(transform.position, _ltPoints[_index].position, Time.deltaTime * _Speed); // 등속 카메라 워크
                transform.LookAt(_MovePointRoot.transform);

                if (Vector3.Distance(transform.position, _ltPoints[_index].position) <= 0.1f)
                {
                    _index++;
                }
            }
            else
            {
                _player = GameObject.FindGameObjectWithTag("Player");
                if (_player != null)
                {
                    Vector3 v = _player.transform.position + _offset;
                    transform.position = Vector3.MoveTowards(transform.position, v, Time.deltaTime * _Speed);
                    transform.LookAt(_MovePointRoot.transform);

                    if(Vector3.Distance(transform.position, v) <= 0.1f)
                    {
                        _eCamState = eCameraActionState.PLAYERSEEKER;

                        // 여기서 게임스테이트를 START로 변경
                        _mngPlay.GameStart();
                    }
                }
            }
        }  

        else
        {
            float rx = Input.GetAxis("Horizontal");
            float ry = Input.GetAxis("Vertical");

            Vector3 vH = (Vector3.up * rx * Time.deltaTime * 10); // 현재 y축 각도
            Vector3 vV = (Vector3.left * ry * Time.deltaTime * 10); // x축 각도

            transform.rotation = Quaternion.Euler(transform.eulerAngles + vH + vV);
        }
    }
}
