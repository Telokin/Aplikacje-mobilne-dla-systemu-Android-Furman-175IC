using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    #region Public object and floats
    [Header("Objects")]

    [SerializeField]
    private GameObject wall = null;

    [SerializeField]
    private GameObject enemy = null;

    [Space]

    [Header("Movement")]

    [SerializeField]
    private float chargeToPlayer = 8;

    [SerializeField]
    private float speed = 4;
    #endregion

    #region Movement properties
    private bool needToRotate = true;
    private Coroutine searchTheWay = null;
    private Ray find;
    private RaycastHit hit;
    #endregion

    #region Out of use
    private float time;
    private bool isCoroutineExecuting = false;
    private Coroutine searchAnotherWay = null;
    private Ray findAnotherPath;
    #endregion

    void Update()
    {


        if (needToRotate)
        {
            searchTheWay = StartCoroutine(FindTheWay());
        }
        else
        {
            MoveOn();
        }

    }


    // Rotator
    private IEnumerator FindTheWay()
    {
      //  Debug.Log("I'm rotating");

            enemy.transform.rotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
            needToRotate = false;
            MoveOn();
        

        yield return null;
    }


    
    // Find path on Z axis and move
    private void MoveOn()
    {
        needToRotate = false;
        find = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(find, out hit))
        {
            // If player spotted charge to him
            if (hit.collider.tag == "Player1")
            {

                enemy.transform.position += transform.forward * Time.deltaTime * chargeToPlayer;
                Debug.LogWarning("CHAAAAAAAAAARGE!!!");
            }

            // If way is free just walk to wall
            else if (hit.distance > 0.5f)
            {
                enemy.transform.position += transform.forward * Time.deltaTime * speed;
             //   Debug.Log("I'm moving " + hitWall.distance);
                
            }

            // No path, go to Coroutine
            else
            {
                enemy.transform.position += transform.forward * Time.deltaTime * 0;
                needToRotate = true;
            //    Debug.Log("I can't go further");
                FindTheWay();
            }
           // ShootRay();
        }

        

    }
}
