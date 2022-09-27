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

        Vector3 position = data.position.ToVector();
        transform.position = position;
    }
}
