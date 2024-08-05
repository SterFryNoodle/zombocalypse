using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float maxDistance = 100f;
    [SerializeField] int weaponDamage = 10;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitFX;

    EnemyHealth target;
    Ammo ammoSlot;
    float bulletImpactLength = .5f;
    float gunBlastDelay = 1f;
    bool canShoot = true;

    void Start()
    {
        ammoSlot = GetComponent<Ammo>();        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            StartCoroutine(Shoot());          
        }
    }    

    IEnumerator Shoot()
    {
        canShoot = false; //Sets flag to prevent player from shooting before coroutine ends.

        if (ammoSlot.AmmoCount() > 0) //Prevents player from being able to shoot when ammo reaches 0.
        {
            PlayMuzzleFX();
            ProcessRaycast();
        }

        ammoSlot.ReduceAmmoAmount();

        yield return new WaitForSeconds(gunBlastDelay);
        canShoot = true; //Resets bool value.
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
        Destroy(impactPt, bulletImpactLength);
    }
}
