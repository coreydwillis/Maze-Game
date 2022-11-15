using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPurple : Enemy
{
    private MainManager manager;
    private AudioSource purpleAudioSource;
    // INHERITANCE
    void Start()
    {
        purpleAudioSource = GetComponent<AudioSource>();
        manager = GameObject.Find("MainManager").GetComponent<MainManager>();
        if (manager.BabyModeOn)
        {
            walkPointRange = 5;
            sightRange = 10f;
            attackRange = 1f;
            timeBetweenAttacks = 1f;
            timeBetweenChases = 20f;
            purpleAudioSource.pitch = 1.6f;
        }
        else
        {
            walkPointRange = 5f;
            sightRange = 20f;
            attackRange = 1f;
            timeBetweenAttacks = 5f;
            timeBetweenChases = 15f;
            purpleAudioSource.pitch = 0.9f;
        }
    }

    public override void Update()
    {
        base.Update();
    }
}