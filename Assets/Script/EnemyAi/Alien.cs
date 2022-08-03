using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform shoot;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float speed = 6f;
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    private void FixedUpdate()
    {
             transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * speed);
        
    }
    

    
}
