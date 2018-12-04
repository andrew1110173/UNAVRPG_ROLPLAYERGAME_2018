using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField]
    float posX;
    [SerializeField]
    float posZ;
    [SerializeField]
    string HeroName;

    public GameData() { }

    public GameData(Dictionary<string, string> data)
    {
        this.posX = float.Parse(data["PosX"]);
        this.posZ = float.Parse(data["PosZ"]);
        this.HeroName = data["Hero"];
    }

    public Vector3 PlayerPosition
    {
        get
        {
            return new Vector3(posX, 0, posZ);
        }
    }

    public string PlayerName
    {
        get
        {
            return HeroName;
        }
    }
}
