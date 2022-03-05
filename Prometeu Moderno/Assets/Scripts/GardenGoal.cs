using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenGoal : Goal
{
    public GardenGoal(string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmout = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
    }

    void HarvestCompleted()
    {
        this.CurrentAmout++;
        Evaluate();
    }
}
