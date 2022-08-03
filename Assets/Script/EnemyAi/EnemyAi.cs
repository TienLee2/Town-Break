using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform shoot;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;
    public float speed = 6f;
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    //Drop bomb
    

    //Attacking
    public float timeBetweenAttacks;
    private float lastShot = 0.0f;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float nonoRange, attackRange;
    public bool  playerInAttackRange;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    private void FixedUpdate()
    {
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            Vector3 lookVector = player.transform.position - transform.position;
            lookVector.y = transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);

            if (!playerInAttackRange)
            {
                Invoke("ChasePlayer", 0.5f);
            }
            if (playerInAttackRange)
            {
                Invoke("AttackPlayer", 0.1f);
            }

    }
   
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        
        
        if (Time.time > timeBetweenAttacks + lastShot)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, shoot.position, Quaternion.identity).GetComponent<Rigidbody>();
            
            
            float randomForce1 = Random.Range(8f, 22f);
            float randomForce2 = Random.Range(1.5f, 2f);
            rb.AddForce(transform.forward * randomForce1, ForceMode.Impulse);
            rb.AddForce(transform.up * randomForce2, ForceMode.Impulse);
            
            
            lastShot = Time.time;
        }
    }

    /*
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    */

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        
    }
}
