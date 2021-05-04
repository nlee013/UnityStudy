using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class FileImageLoad : MonoBehaviour
{
    public int width, height;
    [SerializeField]
    Image loadedImage;
    //test
    public InputField ip;
    Text text;
    string filepath;
    [SerializeField]
    Text file;
    private void Start()
    {
        filepath = Application.persistentDataPath + @"\SaveImage" + @"\" + fileinfo.text + ".png";
        DelegateSampe.Instance.LoadOperate += LoadImage;
    }
    public void LoadImage()
    {

        Debug.Log(filepath);
        filepath = Application.persistentDataPath + @"\SaveImage" + @"\" + text +".png";
        if (File.Exists(filepath))
        {

            var data = File.ReadAllBytes(filepath);
            Texture2D texture = new Texture2D(width, height);
            texture.LoadImage(data);
            Sprite sp = Sprite.Create(texture, new Rect(new Vector2(0, 0), new Vector2(width, height)), new Vector2(0.5f, 0), 1);
            loadedImage.sprite = sp;
        }
    }
    public void GetText(Text text)
        {
        //°ª=<
       text.text =ip.text;

        }
}