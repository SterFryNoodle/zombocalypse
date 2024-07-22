using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float maxDistance = 100f;

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

        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, maxDistance))
        {
            Debug.Log("Hit " + hit.transform.name);

            // Add visual fx to signify when enemy is hit.
            target = hit.transform.GetComponent<EnemyHealth>();
            // Call function to decrease enemy health here.
        }
        else
        {
            return;
        }

        
    }

    
}
