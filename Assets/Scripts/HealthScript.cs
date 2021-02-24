using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider healthBar;

    private int maxHealth = 1000;
    private float currentHealth;

    // Accessible from any script
    public static HealthScript instance;

    // Singleton programming design pattern
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (currentHealth - amount >= 0)
        {
            currentHealth -= amount;
            healthBar.value = currentHealth;
        }
        else
        {
            healthBar.value = 0;
        }
    }

    public float GetCurrentStamina()
    {
        return this.currentHealth;
    }

    public float GetMaxStamina()
    {
        return this.maxHealth;
    }
}
