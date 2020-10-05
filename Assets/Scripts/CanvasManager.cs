using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject winScreen = null;

    [SerializeField]
    private GameObject deathScreen = null;

    [HideInInspector]
    public GameObject dead;

    [HideInInspector]
    public GameObject win;

    
   // public bool isDead;

    void Start()
    {
        DeathScreen();
        WinScreen();
    }

    // Instantiate and assign death screen to Canvas
    private void DeathScreen()
    {
        // Instantiate(deathScreen, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
       // isDead = false;
        Vector3 spawnDeathScreen = new Vector3(401, 203, 0);
        dead = Instantiate(deathScreen, spawnDeathScreen, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        dead.gameObject.SetActive(false);
    }

    private void WinScreen()
    {
        Vector3 spawnWinScreen = new Vector3(401, 203, 0);
        win = Instantiate(winScreen, spawnWinScreen, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        win.gameObject.SetActive(false);
    }
}
