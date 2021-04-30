using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionTest : MonoBehaviour
{
    public static ActionTest Instance
    {
        get;set;
    }
    public Sprite[] sprites;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public event Action MultipleOperate;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MultipleOperate?.Invoke();
        }
    }
}
