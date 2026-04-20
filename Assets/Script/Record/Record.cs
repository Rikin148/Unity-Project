using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Record
{
    public string playerName;
    public int level;
    public float time;

    public Record(string name, int level, float time)
    {
        this.playerName = name;
        this.level = level;
        this.time = time;
    }
}