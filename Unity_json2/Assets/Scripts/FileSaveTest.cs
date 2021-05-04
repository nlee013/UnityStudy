using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;
//일반 형태 파일 저장
public class FileSaveTest : MonoBehaviour
{
    [SerializeField]
    Image im;
    [SerializeField]
    Text nameinfo, ageinfo, mobilenumber, fileinfo;
    string folderPath;
    string filePath;
    private void Start()
    {
        folderPath = Application.persistentDataPath + @"\SaveFile";
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }
    public void SaveInformationFile()
    {
        FileDataFormat fileData = new FileDataFormat(name: nameinfo.text, age: int.Parse(ageinfo.text), mobilenumber: int.Parse(mobilenumber.text), width: im.sprite.texture.width, height: im.sprite.texture.height);
        filePath = @"\"+fileinfo.text + ".json";
        var data = JsonConvert.SerializeObject(fileData);

        File.WriteAllText(folderPath + filePath, data);
    }
}
