using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health;
    public float[] position;
    public float LoadNumber;

    public bool[] buttons;

    public PlayerData (PlayerBehaviour player)
    {
        health = player.health;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        buttons = new bool[3];
        player.loadSlots = new bool[3];
        buttons[0] = player.loadSlots[0];
        buttons[1] = player.loadSlots[1];
        buttons[2] = player.loadSlots[2];
    }
}
