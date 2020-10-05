using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public string exitToMain;
    public string Labirynth;
    
    public void ExitToMainMenu()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(exitToMain);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(Labirynth);
    }
}
