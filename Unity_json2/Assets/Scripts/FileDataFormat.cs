using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FileDataFormat
{
    public string name;
    public int age;
    public int mobilenumber;
    public int width, height;

    public FileDataFormat(string name, int age, int mobilenumber, int width, int height)
    {
        this.name = name;
        this.age = age;
        this.mobilenumber = mobilenumber;
        this.width = width;
        this.height = height;
    }
}
