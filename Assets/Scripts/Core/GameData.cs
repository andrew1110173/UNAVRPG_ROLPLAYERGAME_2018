﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField]
    float posX;
    [SerializeField]
    float posZ;

    public GameData() { }

    public GameData(float posX, float posZ)
    {
        this.posX = posX;
        this.posZ = posZ;
    }

    public Vector3 PlayerPosition
    {
        get
        {
            return new Vector3(posX, 0, posZ);
        }
    }
}
