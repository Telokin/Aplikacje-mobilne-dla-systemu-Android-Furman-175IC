using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string loadLevel;

    public void LoadLevelAt()
    {
        SaveSystem.LoadPlayer();
        SceneManager.LoadScene(loadLevel);
    }
}
