using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;
public class FileLoad : MonoBehaviour
{
    [SerializeField]
    Text nameinfo, ageinfo, mobilenumber, fileinfo;
    string filePath;
    [SerializeField]
    FileImageLoad load;
    private void Start()
    {
        filePath = Application.persistentDataPath + @"\SaveFile" + @"\" + fileinfo.text + ".json";
    }
    public void LoadFile()
    {
        if (File.Exists(filePath))
        {
            var data = File.ReadAllText(filePath);
            var dataObject = JsonConvert.DeserializeObject<FileDataFormat>(data);
            nameinfo.text = dataObject.name;
            ageinfo.text = dataObject.age.ToString();
            mobilenumber.text = dataObject.mobilenumber.ToString();
            load.width = dataObject.width;
            load.height = dataObject.height;
        }
    }
}
