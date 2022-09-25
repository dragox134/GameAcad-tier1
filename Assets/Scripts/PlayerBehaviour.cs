using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float health;
    public float maxHealth = 100;
    public float deltaHealthPercentage;

    public TextMeshProUGUI healthText;

    public Transform healthBar;

    public float saveTime;
    public int saveSlot;
    public int loadSlot;

    public bool[] loadSlots = new bool[3];

    public float fallSpeed = .1f;
    void Start()
    {
        health = maxHealth;
        deltaHealthPercentage = health / maxHealth;
        StartCoroutine(Saving());
    }
    void FixedUpdate()
    {
        float healthPercentage = Mathf.Clamp(health / maxHealth, 0, 1);

        healthText.text = (Mathf.RoundToInt(healthPercentage * 100)).ToString() + "%";

        deltaHealthPercentage = Mathf.Lerp(deltaHealthPercentage, healthPercentage, fallSpeed);

        healthBar.localScale = new Vector3(deltaHealthPercentage, 1, 0);
    }
    
    IEnumerator Saving()
    {
        yield return new WaitForSeconds(saveTime);
        SavePlayer();
        StartCoroutine(Saving());
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, saveSlot);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer(loadSlot);

        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        loadSlots[0] = data.buttons[0];
        loadSlots[1] = data.buttons[1];
        loadSlots[2] = data.buttons[2];
    }
}
