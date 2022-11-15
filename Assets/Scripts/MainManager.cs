using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public bool GameOver { get; set; }
    public bool GameWin { get; set; }

    private float fov;
    public MainManager(float fov)
    {
        fovSet = fov;
    }
    // ENCAPSULATION
    public float fovSet
    {
        get { return fov; } //read
        set
        {
            if (value > 110)
            {
                fov = 110;
            }
            else if (value < 60)
            {
                fov = 60;
            }
            else
            {
                fov = value;
            }
        }
    }

    //public float fovSet;

    //Shard Values
    public int greenShards;
    public int redShards;
    public int purpleShards;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}