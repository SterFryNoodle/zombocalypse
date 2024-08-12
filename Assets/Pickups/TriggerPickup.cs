using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPickup : MonoBehaviour
{    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Picked up some ammo!");
        }
    }
}
