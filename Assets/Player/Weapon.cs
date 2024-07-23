using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float maxDistance = 100f;
    [SerializeField] int weaponDamage = 10;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitFX;

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
        PlayMuzzleFX();
        ProcessRaycast();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, maxDistance)) //Where raycast is being shot out and how far.
        {               
            CreateBulletImpact(hit); // Add visual fx to signify when enemy is hit.

            target = hit.transform.GetComponent<EnemyHealth>(); //Getting the collider of what was hit and accessing the EnemyHealth if it holds that script.            

            if (target == null) //Check if target being hit is able to take damage.
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

    void PlayMuzzleFX()
    {
        muzzleFlash.Play(); //Plays the particle fx.
    }

    void CreateBulletImpact(RaycastHit bullet)
    {
        GameObject impactPt = Instantiate(hitFX, bullet.point, Quaternion.LookRotation(bullet.normal)); //Instantiate impact fx and have the rotation translated towards the normals of object it is on.
        Destroy(impactPt, 1);
    }
}
