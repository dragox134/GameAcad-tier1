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

    public float fallSpeed = .1f;
    void Start()
    {
        health = maxHealth;
        deltaHealthPercentage = health / maxHealth;
    }
    void FixedUpdate()
    {
        float healthPercentage = Mathf.Clamp(health / maxHealth, 0, 1);

        healthText.text = (Mathf.RoundToInt(healthPercentage * 100)).ToString() + "%";

        deltaHealthPercentage = Mathf.Lerp(deltaHealthPercentage, healthPercentage, fallSpeed);

        healthBar.localScale = new Vector3(deltaHealthPercentage, 1, 0);
    }
}
