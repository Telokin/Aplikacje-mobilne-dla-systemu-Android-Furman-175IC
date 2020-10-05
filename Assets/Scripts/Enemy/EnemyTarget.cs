using UnityEngine;
using UnityEngine.UI;

public class EnemyTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 50f;

    [SerializeField]
    private Canvas canvas = null;

    //[SerializeField]
    //private PlayerMovement playerMovement = null;

    [SerializeField]
    private GameObject deathScreen = null;

    private CanvasManager canvasManager;

    private PlayerMovement playerMovement;

    public bool isDead = false;

    private void Update()
    {
        // Show death screen
        if (isDead == true)
        {
            canvasManager.dead.gameObject.SetActive(true);
        }
    }

    void Start()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            isDead = true;
            playerMovement.speed = 0;
        }
    }

}
