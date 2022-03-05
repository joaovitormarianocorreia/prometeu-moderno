using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmout { get; set; }

    public int RequiredAmount { get; set; }

    public virtual void Init()
    {

    }

    public void Evaluate()
    {
        if (CurrentAmout >= RequiredAmount )
        {
            Complete();
        }
    }

    public void Complete()
    {
        Completed = true;
    }
}
