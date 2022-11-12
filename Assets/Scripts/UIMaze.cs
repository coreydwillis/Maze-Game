using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMaze : MonoBehaviour
{
    private MainManager manager;
    //Camera Object
    public Camera mazeCamera;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("MainManager").GetComponent<MainManager>();
        //Set Camera FOV
        mazeCamera.fieldOfView = manager.fovSet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
