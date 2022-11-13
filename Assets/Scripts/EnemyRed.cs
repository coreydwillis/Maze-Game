using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyRed : Enemy
{
    private AudioSource redAudioSource;
    // INHERITANCE
    void Start()
    {
        redAudioSource = GetComponent<AudioSource>();
        redAudioSource.pitch = 2.5f;
        walkPointRange = 20;
        sightRange = 30f;
        attackRange = 1f;
        timeBetweenAttacks = 1f;
    }

    public override void Update()
    {
        base.Update();
    }
}