using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public bool isActive;
    public string description;

    public void SetDescription(string desc)
    {
        this.description = desc;
    }
}
