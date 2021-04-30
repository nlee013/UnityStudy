using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindAndFall : MonoBehaviour
{
    //private int cubeNum = 0;
    public Canvas canvas;
    [SerializeField] Text[] txts;

    public GameObject adam;
    public Text nameContaioner;
    public Transform creactionPosition;

    void Start()
    {
        //var temp = FindObjectsOfType<GameObject>();

        //foreach (var te in temp)
        //{
        //    print(te.name);

        //    if(te.GetComponent<Rigidbody>())
        //    {
        //        te.GetComponent<Rigidbody>().isKinematic = false;
        //    }
            
        //}

        

        
    }

    void Update()
    {
        // Canvas에 랜덤한 숫자로 Text창을 띄워서 Text에 값을 입력해서 화면에 보이게 만들기
      

        //GameObject tempobj = null; // 임시 오브젝트 생성

        //if(cubeNum >0)
        //{
        //    tempobj = GameObject.Find(cubeNum.ToString());

        //    if(tempobj != null)
        //    {
        //        Debug.Log(tempobj.name);
        //    }
        //}




    }

   
}
