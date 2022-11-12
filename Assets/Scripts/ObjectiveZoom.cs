using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveZoom : MonoBehaviour
{
    public Camera m_Camera;
    private float forwardSpeed;
    private float downSpeed;
    private float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        forwardSpeed = 10f;
        downSpeed = 0.75f;
        rotateSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Camera.transform.position.z > -75)
        {
            m_Camera.transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }
        if (m_Camera.transform.position.y > 5)
        {
            m_Camera.transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
        }
        if (m_Camera.transform.position.z < -74)
        {
            m_Camera.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
    }
}
