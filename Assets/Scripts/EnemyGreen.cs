using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGreen : Enemy
{
    private AudioSource screamSound;
    private IEnumerator coroutine;
    private float randRange;

    void Start()
    {
        screamSound = GetComponent<AudioSource>();
        //walkPointRange = 3f;
        sightRange = 1f;
        attackRange = 1f;
        timeBetweenAttacks = 1f;
        randRange = Random.Range(25.0f, 60.0f);
        coroutine = WaitAndSound(randRange);
        StartCoroutine(coroutine);
    }

    // POLYMORPHISM
    public override void Update()
    {
        base.Update();
        float walkRange = Random.Range(5.0f, 300.0f);
        walkPointRange = walkRange;
    }

    private IEnumerator WaitAndSound(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            screamSound.Play();
            StartCoroutine(coroutine);
        }
    }
}