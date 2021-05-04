using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
//그림 저장 클래스
public class FileImageSave : MonoBehaviour
{
    [SerializeField]
    Image source;
    [SerializeField]
    Text file;
    string folderpath, filepath;

    private void Start()
    {
        folderpath = Application.persistentDataPath + @"\SaveImage";
        if (!Directory.Exists(folderpath))
        {
            Directory.CreateDirectory(folderpath);
        }
        DelegateSampe.Instance.SaveOperate += SaveImageFile;
    }
    public void SaveImageFile()
    {
        var data = source.sprite.texture.EncodeToPNG();
        filepath = @"\" + file.text + ".png";

        File.WriteAllBytes(folderpath + filepath, data);
    }
}