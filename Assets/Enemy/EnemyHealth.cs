using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;

    public void TakeDamage(int amtOfDamage)
    {
        hitPoints -= amtOfDamage;

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
