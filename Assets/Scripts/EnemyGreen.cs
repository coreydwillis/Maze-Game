using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGreen : Enemy
{
    private AudioSource creepyAudioSource;
    private AudioClip creepySound;
    private IEnumerator coroutine;
    private float randRange;

    void Start()
    {
        creepyAudioSource = GetComponent<AudioSource>();
        creepyAudioSource.pitch = 0.5f;
        creepySound = AssetDatabase.LoadAssetAtPath("Assets/Sounds/creepy.wav", typeof(AudioClip)) as AudioClip;
        //walkPointRange = 3f;
        sightRange = 15f;
        attackRange = 1f;
        timeBetweenAttacks = 1f;
        randRange = Random.Range(15.0f, 35.0f);
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
            creepyAudioSource.PlayOneShot(creepySound, 25.0f);
            StartCoroutine(coroutine);
        }
    }
}