using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITitleScreen : MonoBehaviour
{
    private MainManager manager;
    public GameObject postProcessing;

    //UI Elements
    public Toggle postProcessingToggle;
    public Button startBTN;
    public Slider fovSlider;
    public TextMeshProUGUI fovValue;

    //Camera Object
    public Camera titleCamera;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("MainManager").GetComponent<MainManager>();
        startBTN.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (postProcessingToggle.isOn)
        {
            postProcessing.SetActive(true);
        }
        else
        {
            postProcessing.SetActive(false);
        }
        manager.fovSet = fovSlider.value;
        //Set Camera FOV
        titleCamera.fieldOfView = manager.fovSet;
        fovValue.text = manager.fovSet.ToString();
    }
    void StartGame()
    {
        SceneManager.LoadScene("Maze");
    }
}