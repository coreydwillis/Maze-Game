using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITitleScreen : MonoBehaviour
{
    private MainManager manager;
    private GameObject postProcessing;

    //UI Elements
    public Toggle postProcessingToggle;
    public Button startBTN;
    public Button exitBTN;
    public Slider fovSlider;
    public TextMeshProUGUI fovValue;

    //Camera Object
    public Camera titleCamera;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("MainManager").GetComponent<MainManager>();
        postProcessing = GameObject.Find("PostProcess");
        startBTN.onClick.AddListener(StartGame);
        exitBTN.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (postProcessingToggle.isOn)
        {
            GameObject postPChild = postProcessing.transform.GetChild(0).gameObject;
            postPChild.SetActive(true);
            postProcessingToggle.isOn = true;
        }
        else
        {
            GameObject postPChild = postProcessing.transform.GetChild(0).gameObject;
            postPChild.SetActive(false);
            postProcessingToggle.isOn = false;
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
    void ExitGame()
    {
        Application.Quit();
    }
}