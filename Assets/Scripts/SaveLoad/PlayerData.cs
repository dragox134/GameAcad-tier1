using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health;
    public SuperVector3 position;
    public float LoadNumber;

    public bool[] buttons;

    public PlayerData (PlayerBehaviour player)
    {
        health = player.health;

        position = new SuperVector3(player.transform.position);
    }

    
}

[System.Serializable]
public class SuperVector3
{
    public float x;
    public float y;
    public float z;
    public SuperVector3(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    public Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }
}
