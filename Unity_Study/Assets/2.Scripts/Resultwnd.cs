using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Resultwnd : MonoBehaviour
{
    [SerializeField] Text _ZombieValTxt;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OpenWnd(int zom)
    {
        _ZombieValTxt.text = zom.ToString();
    }

    public void ClickExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void ClickRestartBtn()
    {
        Scene sc = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sc.name);
    }
}
