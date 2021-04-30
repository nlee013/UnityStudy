using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public abstract class OperateTest : MonoBehaviour
{
    public abstract void Action();

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        ActionTest.Instance.MultipleOperate += Action;
    }

    private void OnDisable()
    {
        ActionTest.Instance.MultipleOperate -= Action;
    }
}
