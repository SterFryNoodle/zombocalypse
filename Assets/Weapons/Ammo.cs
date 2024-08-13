using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    
    [System.Serializable]
    private class AmmoSlot //A private class within this class accessible only by Ammo class.
    {
        public int ammoAmount;
        public AmmoType ammoType;
    }

    public void ReduceAmmoAmount(AmmoType typeOfAmmo) //Passes in variable from Ammoslot private class.
    {
        if (GetAmmoSlot(typeOfAmmo).ammoAmount > 0) //Utilizes the private function to access the ammoAmount variable of w/e weapon slot is being returned.
        {
            GetAmmoSlot(typeOfAmmo).ammoAmount--; //Checks for type of ammo and interates down by 1.
        }
    }

    public void IncreaseAmmoAmount(AmmoType typeOfAmmo, int ammoAmount) //Passes in variable from Ammoslot private class.
    {
        GetAmmoSlot(typeOfAmmo).ammoAmount += ammoAmount; //Checks for type of ammo & adds to it.
    }

    public int AmmoCount(AmmoType typeOfAmmo)
    {
        return GetAmmoSlot(typeOfAmmo).ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType typeOfAmmo)
    {
        foreach (AmmoSlot bulletSlot in ammoSlots) //Goes through each ammo slot on player & checks which type of ammo it is.
        {
            if (bulletSlot.ammoType == typeOfAmmo)
            {
                return bulletSlot;
            }
        }
        return null;
    }
}
