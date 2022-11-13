using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPurple : Enemy
{
    private AudioSource purpleAudioSource;
    // INHERITANCE
    void Start()
    {
        purpleAudioSource = GetComponent<AudioSource>();
        purpleAudioSource.pitch = 0.9f;
        walkPointRange = 2f;
        sightRange = 20f;
        attackRange = 1f;
        timeBetweenAttacks = 5f;
        timeBetweenChases = 15f;
    }

    public override void Update()
    {
        base.Update();
    }
}