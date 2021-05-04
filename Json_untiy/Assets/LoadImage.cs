using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{
    string filePath;
    public Image img;

    void Start()
    {
        filePath = Application.persistentDataPath + @"\saveimage\i.png";
    }

    void Update()
    {
        
    }

    public void LoadedImage()
    {
        if(File.Exists(filePath))
        {
            // json으로 그림 설정 불러와서 width, height에 적용
            var tt = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(width, height);
            texture.LoadImage(tt);
            Sprite sp = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0), 1);
            img.sprite = sp;
        }
    }
}
