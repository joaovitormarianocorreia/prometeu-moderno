using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskBar : MonoBehaviour
{
    public Slider slider;
    public void SetTask(int tasks)
    {
        slider.value = tasks;
    }
}
