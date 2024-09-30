using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateTrap : MonoBehaviour
{
    [SerializeField] Transform trapDoor;
    [SerializeField] int trapDoorDelay = 3;
    [SerializeField] AudioClip trapDoorSound;
    [SerializeField] float travelDistance = 14f;
    [SerializeField] float speed = 2f;

    AudioSource audioSource;
    bool hasEntered = false;
    Vector3 direction = new Vector3(0,0,-1);
    Vector3 startPosition;
    Vector3 endPosition;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startPosition = trapDoor.position;
        endPosition = startPosition + direction.normalized * travelDistance;
    }

    void Update()
    {
        if(hasEntered)
        {
            trapDoor.position = Vector3.MoveTowards(trapDoor.position, endPosition, speed * Time.deltaTime);
        }        
    }

    void OnTriggerEnter()
    {        
        StartCoroutine(DelayTrap());        
    }

    IEnumerator DelayTrap()
    {
        yield return new WaitForSeconds(trapDoorDelay);

        if (trapDoor != null)
        {
            trapDoor.gameObject.SetActive(true);
            audioSource.PlayOneShot(trapDoorSound);
            hasEntered = true;
        }
    }
}
