using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    private EnemyTarget enemyTarget;

    private EndLevel endLevel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        enemyTarget = FindObjectOfType<EnemyTarget>();
        endLevel = FindObjectOfType<EndLevel>();
        mouseSensitivity = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        ShowCursor();

    }

    public void ShowCursor()
    {
        if(enemyTarget.isDead == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mouseSensitivity = 0;
        } 
    }
}
