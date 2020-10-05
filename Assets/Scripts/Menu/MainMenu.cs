using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string playGame;
    public string optionsMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(playGame);
    }

    public void Option()
    {
        SceneManager.LoadScene(optionsMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
