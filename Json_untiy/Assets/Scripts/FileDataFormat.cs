using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FileDataFormat
{
    public string name;
    public int age;
    public string mobilenumber;
    public int width, height;
    public List<string> playerName;

    public FileDataFormat()
    {

    }
    public FileDataFormat(string name, int age, string mobilenumber, int width, int height)
    {
        this.name = name;
        this.age = age;
        this.mobilenumber = mobilenumber;
        this.width = width;
        this.height = height;
    }
}