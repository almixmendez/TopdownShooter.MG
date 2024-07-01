using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        //slider = GetComponent<Slider>();

        if (slider != null)
        {
            float initialHealth = 5;
            SetHealth(initialHealth);
        }
        else
        {
            Debug.LogError("Slider component not found on " + gameObject.name);
        }
    }

    public void ChangeMaxHealth(float maxHealth)
    {
        if (slider != null)
        {
            slider.maxValue = maxHealth;
        }
    }

    public void ChangeActualHealth(float healthAmount)
    {
        if (slider != null)
        {
            slider.value = healthAmount;
        }
    }

    public void IncreaseHealth(float amount)
    {
        if (slider != null)
        {
            float newHealth = slider.value + amount;
        ChangeActualHealth(newHealth);
        }
    }

    public void SetHealth(float healthAmount)
    {
        ChangeMaxHealth(healthAmount);
        ChangeActualHealth(healthAmount);
    }
}
