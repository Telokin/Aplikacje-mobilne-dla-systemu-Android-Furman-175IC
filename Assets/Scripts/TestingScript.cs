using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    [SerializeField]
    private LevelWindow lvlWindow;

    [SerializeField]
    private Player_base player;

    private void Awake()
    {
        LevelSystem lvlSystem = new LevelSystem();
        lvlWindow.SetLevelSystem(lvlSystem);
        player.SetLevelSystem(lvlSystem);
    }
}
