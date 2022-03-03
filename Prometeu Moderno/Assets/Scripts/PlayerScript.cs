using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public int maxTasks = 0;
    public int currentTasks;
    private float healthPeriod = 0.0f;

    public HealthBar healthBar;
    public TaskBar taskBar;
 
    private void Start()
    {
        currentHealth = maxHealth;
        currentTasks = maxTasks;
        healthBar.SetHealth(currentHealth);
        taskBar.SetTask(currentTasks);
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
        healthPeriod += UnityEngine.Time.deltaTime;
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
