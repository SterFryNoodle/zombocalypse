using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Ammo>().IncreaseAmmoAmount(ammoType, ammoAmount); //Finds script on object in scene & calls the function.
            Destroy(gameObject);
            Debug.Log("Picked up some ammo!");
        }
    }
}
