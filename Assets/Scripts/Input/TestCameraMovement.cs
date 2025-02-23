using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestCameraMovement : MonoBehaviour
{
    public float zoomSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-5f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(5f * Time.deltaTime, 0, 0);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize <= 10)
        {
            Camera.main.orthographicSize += 0.5f;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize >= 1)
        {
            Camera.main.orthographicSize -= 0.5f;
        }
    }
}
