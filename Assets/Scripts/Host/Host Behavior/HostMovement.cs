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
    private double degrees;

    private Vector3 oldPosition;

    public float speedModifier = 1f;

    internal void Inizialize(Host host)
    {
        this.host = host;
    }

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = (UnityEngine.Random.value * 10f) - 5f;
        zSpeed = (UnityEngine.Random.value * 10f) - 5f;
        degrees = Math.Atan(xSpeed / zSpeed);

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(xSpeed, 0, zSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = 4 * (gameObject.GetComponent<Rigidbody>().velocity.normalized);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("sex");

        if (collision.gameObject.CompareTag("border") || collision.gameObject.CompareTag("host"))
        {
            Vector3 newPosition = gameObject.transform.position;
            gameObject.transform.position = oldPosition;
            BoxCollider boxCollider = collision.gameObject.GetComponent<BoxCollider>();

            foreach (ContactPoint contact in collision.contacts)
            {
                Collider col = contact.otherCollider;
                if (col is MeshCollider meshCol && !meshCol.convex && meshCol.sharedMesh != null)
                {
                    Vector3 rayStart = contact.point + contact.normal * 0.01f;
                    Vector3 rayDir = -contact.normal;

                    if (col.Raycast(new Ray(rayStart, rayDir), out RaycastHit hit, 1f))
                    {
                        int triIndex = hit.triangleIndex;
                        // Look up triangle vertices, etc.
                    }
                }
            }

            degrees = Math.Atan(xSpeed / zSpeed);
            xSpeed = (float)Math.Sin(-degrees) * 0.005f;
            zSpeed = (float)Math.Cos(-degrees) * 0.005f;
        }
    }*/
}
