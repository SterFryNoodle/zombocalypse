using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;
    [SerializeField] AudioClip deathSound;

    bool isDead = false;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(int amtOfDamage)
    {
        BroadcastMessage("OnDamageTaken"); //Broadcast function in EnemyAI whenever the enemy takes damage.
        hitPoints -= amtOfDamage;

        if (hitPoints <= 0)
        {
            EnemyDead();
        }
    }

    void EnemyDead()
    {
        if (isDead) //prevents animation from starting if enemy is already dead.
        {
            return;
        }

        isDead = true;
        GetComponent<Animator>().SetTrigger("Death");        
    }

    void PlayDeathSFX()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = deathSound;
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
            audioSource.clip = deathSound;
            audioSource.Play();
        }
    }
}
