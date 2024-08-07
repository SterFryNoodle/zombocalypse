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
