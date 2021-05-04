using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveTest : MonoBehaviour
{
    string filePath; // 경로 넣어줄 변수
    string files; // 파일 넣어줄 변수

    void Start()
    {
        filePath = Application.persistentDataPath + @"\saves"; // C:\Users\DMC CONET\AppData\LocalLow\DefaultCompany\Json_untiy
        files = @"\save.json"; // 파일 이름 정함
    }

    public void SaveFile() // 세이브파일 메서드
    {
        if(!Directory.Exists(filePath)) // 파일경로에 디렉토리가 존재하지 않으면
        {
            Directory.CreateDirectory(filePath); // 파일경로에 디렉토리 만들기
        }
        
        SaveFormatTest test = new SaveFormatTest("Ant", 5); // saveFormatTest에 파라미터를 넣어줘서 저장

        var t = JsonUtility.ToJson(test); // t에 Json으로 변환
        var t2 = JsonConvert.SerializeObject(test); // JSON 문자열을 만들기 위해서는 JsonConvert.SerializeObject() 메서드를 사용
        File.WriteAllText(filePath + files, t); // t파일을 filePath 하위에 넣어서 Text를 써줌
    }
}
