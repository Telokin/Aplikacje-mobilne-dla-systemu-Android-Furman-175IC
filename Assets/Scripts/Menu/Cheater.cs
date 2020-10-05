using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cheater : MonoBehaviour
{
    private string TP = "Get Me Out";
    private bool held = true;
    public InputField cheat;
    private EndLevel endLevel;

    //void Update()
    //{
    //    if (Input.GetButton("CheatMode"))
    //    {
    //        //cheat.gameObject.SetActive(true);
    //        ++endLevel.levelAt;
    //    }
    //    //else
    //    //    cheat.gameObject.SetActive(false);
    //    if (Input.GetButton("Reset") == held)
    //    {
    //        //cheat.gameObject.SetActive(true);
    //        PlayerPrefs.DeleteAll();
    //        Debug.LogWarning("Cleared" + endLevel.levelAt);
            
    //    }
    //}

    public void EndLvl()
    {
        if(cheat.text == TP)
        {
            endLevel.gameObject.SetActive(true);
        }
    }
}
