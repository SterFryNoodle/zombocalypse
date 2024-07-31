using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform enemyTarget;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float rotationSpeed = 2f;

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

        if (isProvoked) //Once provoked, call function.
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();

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
        GetComponent<Animator>().SetBool("Attack", false); //Set animation transition states for chasing.
        GetComponent<Animator>().SetTrigger("Walk");
        agent.SetDestination(enemyTarget.position); // Set navmesh agent to it's target position.
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true); //Set animation states for attacking.        
    }

    void FaceTarget()
    {
        Vector3 direction = (enemyTarget.position - transform.position).normalized; //Set vector's magnitude between the enemy & target to be normalized.
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); //Sets variable to be the new rotation based on direction vector.
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed); //Sets enemy rotation to interpolate from current rotation transform
                                                                                                                 //to the new lookRotation @ a set speed.
    }

    void OnDrawGizmosSelected() //Creates visual representation of enemy range.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
