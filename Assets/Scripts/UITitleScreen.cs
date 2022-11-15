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
    public Toggle babyToggle;
    public Button startBTN;
    public Button exitBTN;
    public Button websiteBTN;
    public Button resBackBTN;
    public Button resNextBTN;
    public Slider fovSlider;
    public TextMeshProUGUI fovValue;

    //Camera Object
    public Camera titleCamera;

    //Resolution Variables
    public List<ResItem> resolutions = new List<ResItem>();
    public TMP_Text resolutionLabel;
    private int selectedResolution;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("MainManager").GetComponent<MainManager>();
        postProcessing = GameObject.Find("PostProcess");
        startBTN.onClick.AddListener(StartGame);
        exitBTN.onClick.AddListener(ExitGame);
        websiteBTN.onClick.AddListener(OpenWebsite);

        //Resolution Button listeners
        resBackBTN.onClick.AddListener(ResLeft);
        resNextBTN.onClick.AddListener(ResRight);
        UpdateResolution();
    }

    // Update is called once per frame
    void Update()
    {
        PostProcessing();
        BabyMode();
        manager.fovSet = fovSlider.value;
        //Set Camera FOV
        titleCamera.fieldOfView = manager.fovSet;
        fovValue.text = manager.fovSet.ToString();
    }

    private void PostProcessing()
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
    }
    private void BabyMode()
    {
        if (babyToggle.isOn)
        {
            manager.BabyModeOn = true;
        }
        else
        {
            manager.BabyModeOn = false;
        }
    }

    public void ResLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
        UpdateResolution();
    }

    public void ResRight()
    {
        selectedResolution++;
        if(selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        UpdateResLabel();
        UpdateResolution();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }

    private void UpdateResolution()
    {
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, true);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Maze");
    }
    void ExitGame()
    {
        Application.Quit();
    }

    void OpenWebsite()
    {
        Application.OpenURL("http://coreywillis.com");
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}