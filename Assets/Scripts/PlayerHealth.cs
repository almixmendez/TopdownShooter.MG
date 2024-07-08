using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float health = 5f;
    [SerializeField] public float maxHealth = 5f;
    [SerializeField] public HealthBar healthBar;
    public event EventHandler PlayerDeath;

    private void Start()
    {
        health = maxHealth;
        healthBar.SetHealth(health);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.ChangeActualHealth(health);
        if (health <= 0)
        {
            PlayerDeath?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }

    public void IncreaseHealth(float amount)
    {
        float newHealth = health + amount;
        health = Mathf.Min(newHealth, maxHealth);
        healthBar.ChangeActualHealth(health);
    }

    public void SetHealthBar(HealthBar bar)
    {
        healthBar = bar;
    }
}
