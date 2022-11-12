using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        //Check to see if the game is over
        if (!manager.GameOver)
        {
            //Check to see if the tag on the collider is equal to Objective
            if (other.tag == "Objective")
            {
                manager.GameOver = true;
                manager.GameWin = true;
                Debug.Log(manager.GameOver + " " + manager.GameWin);
            }
            //Check to see if the tag on the collider is equal to Enemy
            if (other.tag == "Enemy")
            {
                if (other.gameObject.name == "Green")
                {
                    if (manager.greenShards > 0)
                    {
                        manager.greenShards--;
                        Destroy(other.gameObject);
                        Destroy(other.transform.parent.gameObject);
                    }
                    else
                    {
                        manager.GameOver = true;
                        manager.GameWin = false;
                    }
                }
                if (other.gameObject.name == "Red")
                {
                    if (manager.redShards > 0)
                    {
                        manager.redShards--;
                        Destroy(other.gameObject);
                        Destroy(other.transform.parent.gameObject);
                    }
                    else
                    {
                        manager.GameOver = true;
                        manager.GameWin = false;
                    }
                }
                if (other.gameObject.name == "Purple")
                {
                    if (manager.purpleShards > 0)
                    {
                        manager.purpleShards--;
                        Destroy(other.gameObject);
                        Destroy(other.transform.parent.gameObject);
                    }
                    else
                    {
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
                    Destroy(other.gameObject);
                }
                if (other.gameObject.name == "Red")
                {
                    manager.redShards++;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.name == "Purple")
                {
                    manager.purpleShards++;
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
