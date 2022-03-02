using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreCrystalText;
    public Text scoreChoresText;

    int crystal = 0;
    int chores = 0;


    // Start is called before the first frame update
    void Start()
    {
        scoreCrystalText.text = "Cristais coletados:" + crystal.ToString();
        scoreChoresText.text = "Tarefas:" + chores.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        crystal += 1;
        scoreCrystalText.text = "Cristais coletados:" + crystal.ToString();
        chores += 1;
        scoreChoresText.text = "Tarefas:" + chores.ToString();
    }
}
