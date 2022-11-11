using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool gameOver;
    public bool win;
    public int greenShards;
    public int redShards;
    public int purpleShards;
    private MainManager manager;

    void Start()
    {
        manager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (manager.GameOver == false)
        {
            if (other.tag == "Objective")
            {
                manager.GameOver = true;
                win = true;
                Debug.Log(manager.GameOver + " " + win);
            }
            if (other.tag == "Enemy")
            {
                if (other.gameObject.name == "Green")
                {
                    if (greenShards > 0)
                    {
                        greenShards--;
                        Destroy(other.gameObject);
                        Destroy(other.transform.parent.gameObject);
                    }
                    else
                    {
                        manager.GameOver = true;
                        win = false;
                        Debug.Log(manager.GameOver + " " + win);
                    }
                }
                if (other.gameObject.name == "Red")
                {
                    if (redShards > 0)
                    {
                        redShards--;
                        Destroy(other.gameObject);
                        Destroy(other.transform.parent.gameObject);
                    }
                    else
                    {
                        manager.GameOver = true;
                        win = false;
                        Debug.Log(manager.GameOver + " " + win);
                    }
                }
                if (other.gameObject.name == "Purple")
                {
                    if (purpleShards > 0)
                    {
                        purpleShards--;
                        Destroy(other.gameObject);
                        Destroy(other.transform.parent.gameObject);
                    }
                    else
                    {
                        manager.GameOver = true;
                        win = false;
                        Debug.Log(manager.GameOver + " " + win);
                    }
                }
            }
            if (other.tag == "Shard")
            {
                if (other.gameObject.name == "Green")
                {
                    greenShards++;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.name == "Red")
                {
                    redShards++;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.name == "Purple")
                {
                    purpleShards++;
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
