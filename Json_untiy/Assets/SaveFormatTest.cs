using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 저장할 파일이 담을 데이터를 모은 클래스
[System.Serializable]
public class SaveFormatTest
{
    public string name;
    public int age;

    public SaveFormatTest(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

}
