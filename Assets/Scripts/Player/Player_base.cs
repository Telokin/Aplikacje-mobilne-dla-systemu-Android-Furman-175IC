using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_base : MonoBehaviour
{
    private LevelSystem lvlSystem;

    

    public void SetLevelSystem(LevelSystem lvlSystem)
    {
        this.lvlSystem = lvlSystem;

    }
}
