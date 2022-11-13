using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MainManager manager;
    private AudioSource audioSource;
    private AudioClip explosionSound;
    private AudioClip attackSound;
    private AudioClip dingSound;
    private AudioClip mazeMusic;

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
    
        explosionSound = AssetDatabase.LoadAssetAtPath("Assets/Sounds/explosion.wav", typeof(AudioClip)) as AudioClip;
        mazeMusic = AssetDatabase.LoadAssetAtPath("Assets/Sounds/Music/MazeMusic.wav", typeof(AudioClip)) as AudioClip;
        attackSound = AssetDatabase.LoadAssetAtPath("Assets/Sounds/attack.wav", typeof(AudioClip)) as AudioClip;
        dingSound = AssetDatabase.LoadAssetAtPath("Assets/Sounds/ding.wav", typeof(AudioClip)) as AudioClip;
        audioSource.PlayOneShot(mazeMusic, 0.25f);
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
                        audioSource.PlayOneShot(explosionSound);
                        Destroy(other.gameObject);
                        Destroy(other.transform.parent.gameObject);
                    }
                    else
                    {
                        audioSource.PlayOneShot(attackSound, 10f);
                        manager.GameOver = true;
                        manager.GameWin = false;
                    }
                }
                if (other.gameObject.name == "Red")
                {
                    if (manager.redShards > 0)
                    {
                        manager.redShards--;
                        audioSource.PlayOneShot(explosionSound);
                        Destroy(other.gameObject);
                        Destroy(other.transform.parent.gameObject);
                    }
                    else
                    {
                        audioSource.PlayOneShot(attackSound, 10f);
                        manager.GameOver = true;
                        manager.GameWin = false;
                    }
                }
                if (other.gameObject.name == "Purple")
                {
                    if (manager.purpleShards > 0)
                    {
                        manager.purpleShards--;
                        audioSource.PlayOneShot(explosionSound);
                        Destroy(other.gameObject);
                        Destroy(other.transform.parent.gameObject);
                    }
                    else
                    {
                        audioSource.PlayOneShot(attackSound, 10f);
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
                    audioSource.PlayOneShot(dingSound, 1.5f);
                    Destroy(other.gameObject);
                }
                if (other.gameObject.name == "Red")
                {
                    manager.redShards++;
                    audioSource.PlayOneShot(dingSound, 1.5f);
                    Destroy(other.gameObject);
                }
                if (other.gameObject.name == "Purple")
                {
                    manager.purpleShards++;
                    audioSource.PlayOneShot(dingSound, 1.5f);
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
