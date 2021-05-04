using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class LoadTest : MonoBehaviour // 파일을 불러올 클래스
{
    string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + @"\saves\save.json"; // C:\Users\DMC CONET\AppData\LocalLow\DefaultCompany\Json_untiy +@"\saves\save.json"
    }

    public void LoadDate() // Data를 로드해주는 메서드
    {
        if(File.Exists(filePath)) // 파일이 존재하면
        {
            var stringdate = File.ReadAllText(filePath); // 데이터를 읽어옴
            var data = JsonConvert.DeserializeObject<SaveFormatTest>(stringdate);
            print(data.name);
            print(data.age);
        }
    }
}
