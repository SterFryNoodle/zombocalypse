using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{    
    [SerializeField] float flashlightIntensity = 20f;
    [SerializeField] AudioClip batterySound;

    AudioSource batterySource;
    float flashlightSpotAngle = 70f;
    float delayTimer = 1f;

    private void Start()
    {
        batterySource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            other.GetComponentInChildren<FlashlightTimer>().RestoreLightAngle(flashlightSpotAngle);
            other.GetComponentInChildren<FlashlightTimer>().RestoreLightIntensity(flashlightIntensity);
            StartCoroutine(PlayBatterySFX());
            Debug.Log("Picked up Battery!");
        }        
    }

    IEnumerator PlayBatterySFX()
    {
        batterySource.clip = batterySound;
        batterySource.Play();

        yield return new WaitForSeconds(delayTimer);
        Destroy(gameObject);
    }
}
