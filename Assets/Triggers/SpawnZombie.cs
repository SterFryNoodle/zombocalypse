using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;
    [SerializeField] int spawnTimer = 1;
    [SerializeField] GameObject gameManager;
    [SerializeField] float lowerVolume = .1f;
    [SerializeField] AudioClip suspenseAudio;

    AudioSource audioSource;
    bool isStartingSequence = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(isStartingSequence)
        {
            TransitionBackgroundMusic();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && enemyObject != null)
        {
            isStartingSequence = true;
            audioSource.clip = suspenseAudio;
            audioSource.Play();
            enemyObject.SetActive(true);
            StartCoroutine(RunIntoDistance());
        }
    }

    void TransitionBackgroundMusic()
    {
        gameManager.GetComponent<AudioSource>().volume -= lowerVolume * Time.deltaTime;        
    }

    IEnumerator RunIntoDistance()
    {
        yield return new WaitForSeconds(spawnTimer);
        enemyObject.SetActive(false);
    }
}
