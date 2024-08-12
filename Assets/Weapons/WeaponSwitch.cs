using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
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
        if (Input.mouseScrollDelta.y > 0)
        {
            //set current weapon to new one.
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
