using Assets.Scripts.Host;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class HostMovement : MonoBehaviour
{
    private Host host;

    private float xSpeed;
    private float zSpeed;
    private float degrees;

    private Vector3 oldPosition;

    public float speedModifier = 1f;

    internal void Inizialize(Host host)
    {
        this.host = host;

    }

    // Start is called before the first frame update
    void Start()
    {
        degrees = UnityEngine.Random.value;
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3((float)Math.Sin(degrees) * speedModifier, 0, (float)Math.Cos(degrees) * speedModifier), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        oldPosition = gameObject.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.transform.position = oldPosition;
    }
    

}
