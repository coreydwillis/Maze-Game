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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (gameOver == false)
        {
            if (other.tag == "Objective")
            {
                gameOver = true;
                win = true;
                Debug.Log(gameOver + " " + win);
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
                        gameOver = true;
                        win = false;
                        Debug.Log(gameOver + " " + win);
                    }
                }
                if (other.gameObject.name == "Red")
                {
                    if (redShards > 0)
                    {
                        redShards--;
                        Destroy(other.gameObject);
                    }
                    else
                    {
                        gameOver = true;
                        win = false;
                        Debug.Log(gameOver + " " + win);
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
                        gameOver = true;
                        win = false;
                        Debug.Log(gameOver + " " + win);
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
