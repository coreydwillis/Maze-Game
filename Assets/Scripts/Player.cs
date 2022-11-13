using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MainManager manager;
    private AudioSource audioSource;
    public AudioClip[] soundEffects;

    void Start()
    {
        SetupAudio();
        manager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetupAudio()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the game is over
        if (!manager.GameOver)
        {
            //Check to see if the tag on the collider is equal to Objective
            if (other.tag == "Objective")
            {
                manager.GameOver = true;
                manager.GameWin = true;
            }
            //Check to see if the tag on the collider is equal to Enemy
            if (other.tag == "Enemy")
            {
                if (other.gameObject.name == "Green")
                {
                    if (manager.greenShards > 0)
                    {
                        manager.greenShards--;
                        audioSource.clip = soundEffects[0];
                        audioSource.Play();
                        Destroy(other.gameObject);
                        Destroy(other.transform.parent.gameObject);
                    }
                    else
                    {
                        audioSource.clip = soundEffects[2];
                        audioSource.Play();
                        manager.GameOver = true;
                        manager.GameWin = false;
                    }
                }
                if (other.gameObject.name == "Red")
                {
                    if (manager.redShards > 0)
                    {
                        manager.redShards--;
                        audioSource.clip = soundEffects[0];
                        audioSource.Play();
                        Destroy(other.gameObject);
                        Destroy(other.transform.parent.gameObject);
                    }
                    else
                    {
                        audioSource.clip = soundEffects[2];
                        audioSource.Play();
                        manager.GameOver = true;
                        manager.GameWin = false;
                    }
                }
                if (other.gameObject.name == "Purple")
                {
                    if (manager.purpleShards > 0)
                    {
                        manager.purpleShards--;
                        audioSource.clip = soundEffects[0];
                        audioSource.Play();
                        Destroy(other.gameObject);
                        Destroy(other.transform.parent.gameObject);
                    }
                    else
                    {
                        audioSource.clip = soundEffects[2];
                        audioSource.Play();
                        manager.GameOver = true;
                        manager.GameWin = false;
                    }
                }
            }
            if (other.tag == "Shard")
            {
                if (other.gameObject.name == "Green")
                {
                    manager.greenShards++;
                    audioSource.clip = soundEffects[3];
                    audioSource.Play();
                    Destroy(other.gameObject);
                }
                if (other.gameObject.name == "Red")
                {
                    manager.redShards++;
                    audioSource.clip = soundEffects[3];
                    audioSource.Play();
                    Destroy(other.gameObject);
                }
                if (other.gameObject.name == "Purple")
                {
                    manager.purpleShards++;
                    audioSource.clip = soundEffects[3];
                    audioSource.Play();
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
