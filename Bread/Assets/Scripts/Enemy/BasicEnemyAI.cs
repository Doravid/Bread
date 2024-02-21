using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyAI : MonoBehaviour
{ 
    private NavMeshAgent agent;

    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public float timeSincePatroll;

    //Enemy Stats
    public int health;
    public string enemyName;
    public QuestManager manager;

    private void Awake()
    {
        if (name == null)
        {
            name = "Enemy";
        }
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform ;
        manager = GameObject.Find("QuestUIController").GetComponent<QuestManager>();
    }
    private void Update()
    {
        //Kills self on 0 HP
        if (health <= 0)
        {
            manager.incrementQuests(gameObject);
            Destroy(gameObject);
        }

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange){ Patrolling(); timeSincePatroll += Time.deltaTime; }
        if(playerInSightRange && !playerInAttackRange){ChasePlayer();}
        if(playerInSightRange && playerInAttackRange){AttackPlayer();}

    }

    private void Patrolling()
    {
        if (!walkPointSet) { SearchWalkPoint(); }
        else agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f || timeSincePatroll > 10)
        {
            walkPointSet = false;
            timeSincePatroll = 0;
        }
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        if (agent == null) return;
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack Code
            Rigidbody rb = Instantiate(projectile, transform.position,Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }
    }
    private void resetAttack()
    {
        alreadyAttacked = false;
    }



}

