using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
   // public int nextSceneLoad;
    public int levelAt = 0;
    private int hub = 5;
    public int endGame = 10;
    private bool held = true;
    private CanvasManager canvasManager;
    private PlayerMovement playerMovement;
    private MouseLook mouseLook;

    public bool won = false;
    public string Hub;
    public string Labirynth;

    private void Start()
    {
        levelAt = PlayerPrefs.GetInt("levelAt");
        canvasManager = FindObjectOfType<CanvasManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        mouseLook = FindObjectOfType<MouseLook>();
    }

    void Update()
    {

        if (levelAt == endGame)
        {
            
            playerMovement.speed = 0;
            canvasManager.win.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mouseLook.mouseSensitivity = 0;
            PlayerPrefs.DeleteAll();

        }

        if (Input.GetButton("CheatMode"))
        {
            //cheat.gameObject.SetActive(true);
            ++levelAt;
            if (levelAt == hub || levelAt == endGame)
            {


                PlayerPrefs.SetInt("levelAt", levelAt);
                SceneManager.LoadScene(Hub);
                Debug.LogWarning("I'm at hub/boss lvl: " + levelAt);
            }
            else
            {
                PlayerPrefs.SetInt("levelAt", levelAt);
                SceneManager.LoadScene(Labirynth);
                Debug.LogWarning("I'm at lvl: " + levelAt);
            }
        }
        //else
        //    cheat.gameObject.SetActive(false);
        if (Input.GetButton("Reset") == held)
        {
            //cheat.gameObject.SetActive(true);
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.LogWarning("Cleared" + levelAt);

        }
    }
    void OnTriggerEnter(Collider other)
    { 
        
        if(other.gameObject.tag == "Player1")
        {
            ++levelAt;
            SaveSystem.SavePlayer(this);
            Debug.LogWarning("I'm at normal lvl: " + levelAt);



            if (levelAt > PlayerPrefs.GetInt("levelAt"))
            {
                
                if (levelAt == hub || levelAt == endGame)
                {
                    
                    
                    PlayerPrefs.SetInt("levelAt", levelAt);
                    SceneManager.LoadScene(Hub);
                    Debug.LogWarning("I'm at hub/boss lvl: " + levelAt);
                }
                else
                {
                    PlayerPrefs.SetInt("levelAt", levelAt);
                    SceneManager.LoadScene(Labirynth);
                }
                   
            }
           

        }
    }

    public void PlayerDeath()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

}
