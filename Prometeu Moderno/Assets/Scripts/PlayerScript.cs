using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 6; // Delimita o nível máximo de pontos de saúde do jogador
    public int currentHealth; // Armazena o nível de saúde do jogador
    public int maxTasks = 6; // Delimita o nível máximo de pontos de tarefa do jogador
    public int currentTasks; // Delimita o nível atual de saúde do jogador 
    private float decreaseHealth = 0.0f; // Timer para diminuir o nível de saúde 
    private float decreaseTask = 0.0f; // Timer para diminuir o nível de pontos de tarefas
    private float taskPeriod = 0.0f; // Timer para atribuição de tarefas

    private float sec = 3.0f; // Valor de exibição de mensagem de tarefa concluída
    private bool gardenTaskAssigned = false; // Booleana de atribuição de tarefa do jardim 
    private bool gardenTaskCompleted = false; // Booleana de finalização de tarefa do jardim
    private bool forestTaskAssigned = false; // Booleana de atribuição de tarefa da floresta
    [SerializeField] private Camera camera;
    [SerializeField] private AudioClip audio;

    public HealthBar healthBar; // Barra de nível de pontos de saúde
    public TaskBar taskBar; // Barra de nível das tarefas 
    public GameObject gardenTaskWindow; // Janela de exibição do enunciado da tarefa do jardim
    public GameObject goalGardenTask; // Objeto de objetivo da tarefa do jardim
    public Light gardenTaskLight; // Iluminação do objetivo do jardim 
    public GameObject forestTaskWindow; // Janela de exibição do enunciado da tarefa da floresta
    public GameObject goalForestTask; // Objeto de objetivo da tarefa da floresta
    public Light forestTaskLight; // Iluminação do objetivo da floresta
    public GameObject taskFinished; // Objeto da mensagem de tarefa 
    

    private void Start()
    {
        // Inicialização dos níveis 
        currentHealth = maxHealth;
        currentTasks = maxTasks;
        healthBar.SetHealth(currentHealth);
        taskBar.SetTask(currentTasks);
        // Inicialização dos objetos das luzes
        gardenTaskLight = goalGardenTask.GetComponent<Light>();
        gardenTaskLight.enabled = false;
        forestTaskLight = goalForestTask.GetComponent<Light>();
        forestTaskLight.enabled = false;
    }

    void Update()
    {
        if (decreaseHealth > 15.0)
            UpdateHealthBar();
        if (decreaseTask > 20.0)
            UpdateTaskBar();
        if (taskPeriod > 10.0)
        {
            OpenQuestWindow();
            taskPeriod = 0;
        }
        decreaseHealth += UnityEngine.Time.deltaTime;
        decreaseTask += UnityEngine.Time.deltaTime;
        taskPeriod += UnityEngine.Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cristals")
        {
            other.gameObject.SetActive(false);
            if (currentHealth < 5)
            {
                decreaseHealth = 0;
                currentHealth++;
                healthBar.SetHealth(currentHealth);
            }
        }
        if (other.tag == "Goals")
        {
            CloseQuestWindow();
        }
    }

    public void UpdateHealthBar()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            healthBar.SetHealth(currentHealth);
        }
        decreaseHealth = 0;
    }
    public void UpdateTaskBar()
    {
        if (currentTasks > 0)
        {
            currentTasks--;
            taskBar.SetTask(currentTasks);
        }
        decreaseTask = 0;
    }

    public void OpenQuestWindow()
    {
        // Atribui a tarefa de colheita
        if (gardenTaskAssigned == false && forestTaskAssigned == false)
        {
            gardenTaskWindow.SetActive(true);
            gardenTaskLight = goalGardenTask.GetComponent<Light>();
            gardenTaskLight.enabled = true;
            gardenTaskAssigned = true;
        }
        // Atribui a tarefa da floresta
        if (gardenTaskAssigned == true && gardenTaskCompleted == true && forestTaskAssigned == false)
        {
            forestTaskWindow.SetActive(true);
            forestTaskLight = goalForestTask.GetComponent<Light>();
            forestTaskLight.enabled = true;
            forestTaskAssigned = true;
        }
    }

    public void CloseQuestWindow()
    {
        // Aumenta o número de tarefas realizadas
        currentTasks += 1;
        taskBar.SetTask(currentTasks);
        if (gardenTaskAssigned == true && forestTaskAssigned == false)
        {
            AudioSource.PlayClipAtPoint(audio, camera.transform.position);
            gardenTaskWindow.SetActive(false);
            goalGardenTask.SetActive(false);
            gardenTaskCompleted = true;
            taskPeriod = 0;
            decreaseTask = 0;
        }
        if (gardenTaskAssigned == true && forestTaskAssigned == true)
        {
            AudioSource.PlayClipAtPoint(audio, camera.transform.position);
            forestTaskWindow.SetActive(false);
            goalForestTask.SetActive(false);
            decreaseTask = 0;
        }
        taskFinished.SetActive(true);
        StartCoroutine(DisableMessage(sec));
    }

    IEnumerator DisableMessage(float seconds)
    {
        yield return new WaitForSeconds(seconds);
         
        taskFinished.SetActive(false);
    }
}
