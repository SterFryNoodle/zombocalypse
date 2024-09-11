using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{    
    [SerializeField] float flashlightIntensity = 20f;

    float flashlightSpotAngle = 70f;            
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInChildren<FlashlightTimer>().RestoreLightAngle(flashlightSpotAngle);
            GetComponentInChildren<FlashlightTimer>().RestoreLightIntensity(flashlightIntensity);
            Destroy(gameObject);
            Debug.Log("Picked up Battery!");
        }        
    }
}
