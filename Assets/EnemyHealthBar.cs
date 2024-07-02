using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private float initialEnemyHealth = 5;

    private void Start()
    {
        //slider = GetComponent<Slider>();
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }

        if (slider == null)
        {
            Debug.LogError("Slider component not found on " + gameObject.name);
        }
        else
        {
            SetHealth(initialEnemyHealth);
            Debug.Log("Slider initialized with health: " + initialEnemyHealth);
        }
    }

    public void ChangeMaxHealth(float maxHealth)
    {
        if (slider != null)
        {
            slider.maxValue = maxHealth;
            Debug.Log("Max health set to: " + maxHealth);
        }
    }

    public void ChangeActualHealth(float healthAmount)
    {
        if (slider != null)
        {
            slider.value = healthAmount;
            Debug.Log("Health bar value changed to: " + healthAmount);
        }
    }

    public void SetHealth(float healthAmount)
    {
        ChangeMaxHealth(healthAmount);
        ChangeActualHealth(healthAmount);
    }
}
