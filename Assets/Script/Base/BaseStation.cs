using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseStation : MonoBehaviour
{
    public Text HealthText;
    public float currentHealth;
    public float maximumHealth;

    private void Start()
    {
        maximumHealth = currentHealth;
    }

    private void Update()
    {
        HealthText.text = (currentHealth / maximumHealth).ToString();

        if (currentHealth <= 0)
        {
            GameManager.instace.state = false;
        }
    }
}
