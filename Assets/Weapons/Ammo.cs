using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmt = 15;
    
    public void ReduceAmmoAmount() 
    {
        if (ammoAmt > 0)
        {
            ammoAmt--;
        }               
    }

    public int AmmoCount()
    {
        Debug.Log("There is " + (ammoAmt - 1) + " bullets left"); //Weird bug where ammo reduces below 0 b/c it doesn't count the first bullet.
        return ammoAmt;
    }
}
