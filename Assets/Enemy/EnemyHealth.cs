using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;

    bool isDead = false;

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

    private void EnemyDead()
    {
        if (isDead) //prevents animation from starting if enemy is already dead.
        {
            return;
        }

        isDead = true;
        GetComponent<Animator>().SetTrigger("Death");
    }
}
