using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    [SerializeField] AudioClip pickupSound;

    AudioSource pickupSource;
    float soundFXTimer = 1f;
    void Start()
    {
        pickupSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            FindObjectOfType<Ammo>().IncreaseAmmoAmount(ammoType, ammoAmount); //Finds script on object in scene & calls the function.
            StartCoroutine(PlayPickupSFX());            
            Debug.Log("Picked up some ammo!");
        }
    }

    IEnumerator PlayPickupSFX()
    {
        pickupSource.clip = pickupSound;
        pickupSource.Play();

        yield return new WaitForSeconds(soundFXTimer);
        Destroy(gameObject);
    }
}
