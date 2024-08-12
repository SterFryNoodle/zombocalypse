using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] public int currentWeapon = 0;
    [SerializeField] List<WeaponSwitch> weapons;

    void Start()
    {
        SetWeaponActive();
    }
    
    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessMouseScroll();

        if (previousWeapon != currentWeapon) //Sets new weapon selected to be the active.
        {
            SetWeaponActive();
        }
    }

    void ProcessMouseScroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            currentWeapon++;

            if (currentWeapon > transform.childCount - 1) //Checks if currentWeapon index is greater than # of weapons.
            {
                currentWeapon = 0; //Resets the index back to first one if it goes over.
            }            
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0) //Does same thing but opposite direction of mouse scroll.
        {
            currentWeapon--;

            if (currentWeapon < 0)
            {
                currentWeapon = transform.childCount - 1;
            }            
        }
    }

    void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform) //Finds the transform of each child object from object script is attached to.
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++; //Adds counter to check index of each weapon child until it finds the right one.
        }
    }
}
