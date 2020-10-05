using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSystem
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private int level;
    private int experience;
    private int expToLvlUp;

    public LevelSystem()
    {
        level = 0;
        experience = 0;
        expToLvlUp = 100;
    }

    public void AddExp(int amount)
    {
        experience += amount;
        if(experience>= expToLvlUp)
        {
            level++;
            experience -= expToLvlUp;
            if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public float GetExperienceNormalized()
    {
        return (float)experience / expToLvlUp;
    }
}
