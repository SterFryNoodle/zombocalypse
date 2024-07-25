using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform enemyTarget;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
        
    void Update()
    {
        SetEnemyRange();
    }

    void SetEnemyRange()
    {
        distanceToTarget = Vector3.Distance(enemyTarget.position, transform.position); //Set variable to distance between player & enemy.
        
        if (isProvoked)
        {            
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);        
    }

    void EngageTarget()
    {        
        if (distanceToTarget > agent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= agent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {        
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Walk");
        agent.SetDestination(enemyTarget.position);
    }

    void AttackTarget()
    {        
        GetComponent<Animator>().SetBool("Attack", true);
        Debug.Log("Enemy has attacked.");
    }
}
