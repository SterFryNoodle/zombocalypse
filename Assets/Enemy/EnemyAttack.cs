using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform targetStrike;
    [SerializeField] float damageDone = 20f;
    
    void Start()
    {
        
    }

    public void AttackHitReturn()
    {
        if(targetStrike == null)
        {
            return;
        }

        Debug.Log("20 damage to player.");
    }
}
