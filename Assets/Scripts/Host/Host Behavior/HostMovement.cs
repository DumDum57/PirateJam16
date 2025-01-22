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

    private float degrees;

    public float speedModifier = 1f;

    internal void Inizialize(Host host)
    {
        this.host = host;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(UnityEngine.Random.Range(-1f, 1f) + 0.001f, 0, UnityEngine.Random.Range(-1f, 1f) + 0.001f) * speedModifier;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * speedModifier;
    }
}
