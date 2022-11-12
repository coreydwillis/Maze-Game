using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMaze : MonoBehaviour
{
    private MainManager manager;
    //Camera Object
    public Camera mazeCamera;
    // UI Elements
    //Shards
    public TextMeshProUGUI redShards;
    public TextMeshProUGUI purpleShards;
    public TextMeshProUGUI greenShards;
    //Game Status Conditions
    public TextMeshProUGUI gameLost;
    public TextMeshProUGUI gameWon;
    public Button startOver;

    void Start()
    {
        manager = GameObject.Find("MainManager").GetComponent<MainManager>();
        //Set Camera FOV
        mazeCamera.fieldOfView = manager.fovSet;
        startOver.onClick.AddListener(StartOver);
    }

    // Update is called once per frame
    void Update()
    {
        redShards.text = manager.redShards.ToString();
        purpleShards.text = manager.purpleShards.ToString();
        greenShards.text = manager.greenShards.ToString();

        if (manager.GameOver)
        {
            if (manager.GameWin)
            {
                gameWon.gameObject.SetActive(true);
                startOver.gameObject.SetActive(true);
            }
            else
            {
                gameLost.gameObject.SetActive(true);
                startOver.gameObject.SetActive(true);
            }
        }
    }

    void StartOver()
    {
        manager.GameOver = false;
        manager.GameWin = true;
        manager.redShards = 0;
        manager.purpleShards = 0;
        manager.greenShards = 0;
        SceneManager.LoadScene("TitleScreen");
    }
}