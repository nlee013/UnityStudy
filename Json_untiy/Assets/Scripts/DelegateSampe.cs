using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DelegateSampe : MonoBehaviour
{
    #region 속성
    public static DelegateSampe Instance
    {
        get; set;
    }
    #endregion

    #region 이벤트(대리자)
    public event Action SaveOperate;
    public event Action LoadOperate;
    public event EventHandler SaveEvent;
    public event EventHandler LoadEvent;
    #endregion
    #region 함수
    public void SaveOperation()
    {
        SaveOperate?.Invoke();
    }
    public void LoadOperation()
    {
        LoadOperate?.Invoke();
    }
    public void SaveEventOperation()
    {
        SaveEvent?.Invoke(this, EventArgs.Empty);
    }
    public void LoadEventOperation()
    {
        LoadEvent?.Invoke(this, EventArgs.Empty);
    }
    #endregion

    #region 유니티 함수
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion


}