using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGreen : Enemy
{
    private MainManager manager;
    private AudioSource creepyAudioSource;
    private IEnumerator coroutine;
    private float randRange;

    void Start()
    {
        creepyAudioSource = GetComponent<AudioSource>();
        manager = GameObject.Find("MainManager").GetComponent<MainManager>();
        if (manager.BabyModeOn)
        {
            sightRange = 15f;
            attackRange = 1f;
            timeBetweenAttacks = 1f;
            timeBetweenChases = 25f;
            creepyAudioSource.pitch = 1f;
        }
        else
        {
            sightRange = 20f;
            attackRange = 1f;
            timeBetweenAttacks = 1f;
            timeBetweenChases = 15f;
            creepyAudioSource.pitch = 0.45f;
        }
        randRange = Random.Range(35.0f, 70.0f);
        coroutine = WaitAndSound(randRange);
        StartCoroutine(coroutine);
    }

    // POLYMORPHISM
    public override void Update()
    {
        base.Update();
        float walkRange = Random.Range(10f, 50f);
        walkPointRange = walkRange;
    }

    private IEnumerator WaitAndSound(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            creepyAudioSource.clip = soundEffects[3];
            creepyAudioSource.Play();
            StartCoroutine(coroutine);
        }
    }
}