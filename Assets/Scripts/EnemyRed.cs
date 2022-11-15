using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyRed : Enemy
{
    private MainManager manager;
    private AudioSource redAudioSource;
    // INHERITANCE
    void Start()
    {
        redAudioSource = GetComponent<AudioSource>();
        manager = GameObject.Find("MainManager").GetComponent<MainManager>();
        if (manager.BabyModeOn)
        {
            walkPointRange = 5;
            sightRange = 15f;
            attackRange = 1f;
            timeBetweenAttacks = 1f;
            timeBetweenChases = 10f;
            redAudioSource.pitch = 3f;
        }
        else
        {
            walkPointRange = 10;
            sightRange = 30f;
            attackRange = 1f;
            timeBetweenAttacks = 1f;
            timeBetweenChases = 5f;
            redAudioSource.pitch = 1.3f;
        }
    }

    public override void Update()
    {
        base.Update();
    }
}