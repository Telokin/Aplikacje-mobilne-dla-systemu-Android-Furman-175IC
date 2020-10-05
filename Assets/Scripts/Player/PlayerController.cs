using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float damage = 10f;
    public float range = 50;
    public float fireRate = 15f;
    public Interactable focus;

    public Camera fpsCam;
    public GameObject impactEffect;
    public GameObject inventoryUI;
    


    private float nextTimeToFire = 0f;
    void Update()
    {
        if (Input.GetButton("Fire1")  &&  Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            RemoveFocus();
        }

        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            Debug.Log(Input.GetButtonDown("Inventory") + "Show up Inventory");

        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
               Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    

void Shoot()
    {
        RaycastHit hit;
       if( Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
           EnemyTarget enemy = hit.transform.GetComponent<EnemyTarget>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            GameObject imactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(imactGO, 2f);
        }
    }

    void SetFocus(Interactable newFocus)
    {

        if(newFocus != focus)
        {
            if(focus != null)
            focus.OnDefocused();
            focus = newFocus;
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if(focus != null)
        focus.OnDefocused();
        focus = null;
    }

}

