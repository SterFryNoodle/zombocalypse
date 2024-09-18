using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;
    [SerializeField] int spawnTimer = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && enemyObject != null)
        {
            enemyObject.SetActive(true);
            StartCoroutine(RunIntoDistance());
        }
    }
    
    IEnumerator RunIntoDistance()
    {
        yield return new WaitForSeconds(spawnTimer);
        enemyObject.SetActive(false);
    }
}
