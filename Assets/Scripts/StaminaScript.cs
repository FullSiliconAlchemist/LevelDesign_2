using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScript : MonoBehaviour
{
    public Slider staminaBar;
    public float staminaRecovery = 0.00001f;

    private int maxStamina = 1000;
    private float currentStamina;

    // Accessible from any script
    public static StaminaScript instance;

    // Singleton programming design pattern
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(float amount)
    {
        if (currentStamina - amount >= amount)
        {
            // Has enough stamina
            currentStamina -= amount;
            staminaBar.value = currentStamina;
        }
        else
        {
            staminaBar.value = 0;
            Debug.Log("Not enough stamina");
        }
    }

    public void RecoverStamina()
    {
        if (currentStamina < maxStamina)
        {
            // Recovery
            currentStamina += staminaRecovery;
            staminaBar.value = currentStamina;
        }
    }

    public float GetCurrentStamina()
    {
        return this.currentStamina;
    }

    public float GetMaxStamina()
    {
        return this.maxStamina;
    }
}
