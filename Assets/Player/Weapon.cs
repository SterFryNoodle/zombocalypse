using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float maxDistance = 100f;
    [SerializeField] int weaponDamage = 10;

    EnemyHealth target;
    void Update()
    {        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, maxDistance)) //Where raycast is being shot out and how far.
        {
            Debug.Log("Hit " + hit.transform.name);

            // Add visual fx to signify when enemy is hit.

            target = hit.transform.GetComponent<EnemyHealth>(); //Getting the collider of what was hit and accessing the EnemyHealth if it holds that script.            
            
            if (target != null) //Check if target being hit is able to take damage.
            {
                return;
            }
            else
            {
                target.TakeDamage(weaponDamage); //Calling function to decrease health.
            }            
        }
        else
        {
            return;
        }

        
    }

    
}
