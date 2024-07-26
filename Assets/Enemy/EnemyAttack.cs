using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{    
    [SerializeField] int attackDamage = 20;

    PlayerHealth targetStrike;    
    void Start()
    {        
        targetStrike = FindObjectOfType<PlayerHealth>();
    }

    void AttackHitReturn()
    {
        if(targetStrike == null)
        {
            return;
        }
        else
        {
            targetStrike.PlayerTakesDamage(attackDamage);
        }        
    }
}
