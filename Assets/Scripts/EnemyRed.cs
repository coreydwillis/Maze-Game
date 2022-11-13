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
        redAudioSource.pitch = 1.3f;
        walkPointRange = 20;
        sightRange = 30f;
        attackRange = 1f;
        timeBetweenAttacks = 1f;
        timeBetweenChases = 15f;
    }

    public override void Update()
    {
        base.Update();
    }
}