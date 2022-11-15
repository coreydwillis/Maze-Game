using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    private AudioSource audioSource;
    public LayerMask whatIsGround, whatIsPlayer;
    public AudioClip[] soundEffects;
    private MainManager manager;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //Chasing Sounds
    public float timeBetweenChases;
    bool alreadyChased;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public ParticleSystem explosion;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        LoadAudio();
        agent = GetComponent<NavMeshAgent>();
        manager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    public virtual void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    // ABSTRACTION
    private void LoadAudio()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint Reached
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, whatIsGround)) walkPointSet = true;
    }

    private void ChasePlayer()
    {
        if (!alreadyChased && manager.FlashOn)
        {
            audioSource.clip = soundEffects[0];
            audioSource.Play();
            //Attack logic goes here
            alreadyChased = true;
            Invoke(nameof(ResetChased), timeBetweenChases);
        }
        if (manager.FlashOn)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            Patroling();
        }
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked && manager.FlashOn)
        {
            //Attack logic goes here
            audioSource.clip = soundEffects[2];
            audioSource.Play();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
        private void ResetChased()
    {
        alreadyChased = false;
    }

    private void TakeDamage()
    {
        Destroy(gameObject);
    }
}