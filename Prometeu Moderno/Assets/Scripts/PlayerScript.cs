using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 6;
    public int currentHealth;
    public int maxTasks = 6;
    public int currentTasks = 0;
    private float healthPeriod = 0.0f;
    private float taskPeriod = 0.0f; 

    public HealthBar healthBar;
    public TaskBar taskBar;
    public Quest questWindow;

    private void Start()
    {
        currentHealth = maxHealth;
        currentTasks = maxTasks;
        healthBar.SetHealth(currentHealth);
        taskBar.SetTask(currentTasks);
        questWindow.SetDescription("Recolha galhos na floresta antiga");
    }
    
    void Update()
    {
        if (healthPeriod > 5.0)
        {
            if (currentHealth > 0)
            {
                currentHealth--;
                healthBar.SetHealth(currentHealth);
            }
            healthPeriod = 0;
        }
        if (taskPeriod > 10.0)
        {
            OpenQuestWindow();
        }
        healthPeriod += UnityEngine.Time.deltaTime;
        taskPeriod += UnityEngine.Time.deltaTime;
    }

    public void OpenQuestWindow()
    {
        //questWindow.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cristals")
        {
            other.gameObject.SetActive(false);
            if (currentHealth < 5)
            {
                healthPeriod = 0;
                currentHealth++;
                healthBar.SetHealth(currentHealth);
            }
        }
    }
}
