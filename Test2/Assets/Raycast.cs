using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private int colorNum = 1;
    Renderer mat;

    public float m_fSpeed = 5.0f;
    Vector3 m_vecTarget;
    void Start()
    {
        mat = GetComponent<Renderer>();
        m_vecTarget = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라 기준에 마우스 포지션값을 ray에 넣어줌
            RaycastHit hit; // 충돌한 부분을 hit으로 가져옴
            if (Physics.Raycast(ray, out hit, 10000f)) // Raycast 발사
            {
                m_vecTarget = hit.point; // 타겟을 충돌 포인트로 지정
                SwitchColor();

            }
        }

        transform.position = Vector3.MoveTowards(transform.position, m_vecTarget, m_fSpeed * Time.deltaTime); // 이동하기

    }


    void SwitchColor()
    {
        switch (colorNum)
        {
            case 0:
                mat.material.color = Color.white;
                break;
            case 1:
                mat.material.color = Color.green;
                break;
            case 2:
                mat.material.color = Color.blue;
                break;
            case 3:
                mat.material.color = Color.black;
                break;
            case 4:
                mat.material.color = Color.grey;
                break;
            case 5:
                mat.material.color = Color.yellow;
                break;

        }
        colorNum++;
        if (colorNum > 6)
        {
            colorNum -= 7;
        }
    }
}
