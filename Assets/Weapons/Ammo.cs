using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] slots;
    
    [System.Serializable]
    private class AmmoSlot //A private class within this class accessible only by Ammo class.
    {
        public int ammoAmount;
        public AmmoType ammoType;
    }

    //public void ReduceAmmoAmount() 
    //{
    //    if (ammoAmt > 0)
    //    {
    //        ammoAmt--;
    //    }               
    //}

    //public int AmmoCount()
    //{
    //    Debug.Log("There is " + (ammoAmt) + " bullets left"); //Weird bug where ammo reduces below 0 b/c it doesn't count the first bullet.
    //    return ammoAmt;
    //}
}
