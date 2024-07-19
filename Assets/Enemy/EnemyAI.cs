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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
        
    void Update()
    {
        SetEnemyRange();
    }

    private void SetEnemyRange()
    {
        distanceToTarget = Vector3.Distance(enemyTarget.position, transform.position); //Set variable to distance between player & enemy.

        if (distanceToTarget < chaseRange)
        {
            agent.SetDestination(enemyTarget.position);
        }
    }
}
