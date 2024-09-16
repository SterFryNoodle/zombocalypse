using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateTrap : MonoBehaviour
{
    [SerializeField] Transform trapDoor;
    [SerializeField] int trapDoorDelay = 3;
            
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
        }
    }
}
