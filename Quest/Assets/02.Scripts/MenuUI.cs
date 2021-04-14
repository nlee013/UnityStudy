using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text text;

    private void Start()
    {
        button.onClick.AddListener(() => { text.text = "버튼 클릭!"; });
    }
}
