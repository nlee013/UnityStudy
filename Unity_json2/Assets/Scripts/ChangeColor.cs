using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    Image buttonImage;

    public void Change()
    {
        int temp = Random.Range(0, 5);
        Color buttonColor = new Color(0,0,0);
        switch (temp)
        {
            case 0:
                buttonColor = new Color(0.04f, 0.2f, 0.3f);
                break;
            case 1:
                buttonColor = new Color(0.8f, 0.2f, 0.3f);
                break;
            case 2:
                buttonColor = new Color(0.04f, 0.8f, 0.3f);
                break;
            case 3:
                buttonColor = new Color(0.04f, 0.2f, 0.8f);
                break;
            case 4:
                buttonColor = new Color(0.04f, 0.8f, 0.8f);
                break;
        }
        buttonImage.color = buttonColor;
    }

    public void RevertChange()
    {
        buttonImage.color = Color.white;
    }
}
