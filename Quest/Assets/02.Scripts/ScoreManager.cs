using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    
        public GameObject gameoverText; // 게임오버 시 활성화할 텍스트 게임 오브젝트
        private float score; // 스코어 점수 변수
        private Text scoreTxt;  // 스코어 텍스트
        private bool isGameover;    // 게임오버 상태

        void Start()
        {
            // 생존 시간과 게임오버 상태 초기화
            score = 0;
            isGameover = false;
        }


        void Update()
        {
            if (!isGameover)    // 게임오버가 아닌 동안
            {
                // 시간 증가 함수 실행
            }

            else
            {
                if (Input.GetKeyDown(KeyCode.R))    // 게임오버 상태에서 R키를 누른 경우
                {
                    SceneManager.LoadScene("SampleScene");  // SampleScene 씬으로 로드
                }
            }

        }

        public void EndGame()   // 현재 게임을 게임오버 상태로 변경하는 메서드
        {
            isGameover = true;  // 현재 상태를 게임오버 상태로 전환
            gameoverText.SetActive(true);   // 게임오버 텍스트 게임 오브젝트를 활성화


             scoreTxt.text = "Score :" + (int)score; // 최고기록을 recordText 텍스트 컴포넌트를 이용해 표시
        }
}
