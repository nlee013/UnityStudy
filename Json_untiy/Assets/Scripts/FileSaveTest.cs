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
        DelegateSampe.Instance.SaveOperate += SaveInformationFile;



    }
    public void SaveInformationFile()
    {
        var filedata = new FileDataFormat();
        filedata.name = nameinfo.text;
        filedata.age = int.Parse(ageinfo.text);
        filedata.mobilenumber = mobilenumber.text;
        filedata.width = im.sprite.texture.width;
        filedata.height = im.sprite.texture.height;

        //FileDataFormat fileData = new FileDataFormat(name: nameinfo.text, age: int.Parse(ageinfo.text), mobilenumber: mobilenumber.text, width: im.sprite.texture.width, height: im.sprite.texture.height);
        filePath = @"\" + fileinfo.text + ".json";
        var data = JsonConvert.SerializeObject(filedata);

        File.WriteAllText(folderPath + filePath, data);
    }
}