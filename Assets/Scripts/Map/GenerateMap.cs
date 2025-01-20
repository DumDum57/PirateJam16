using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public Vector3 startingPoint;
    public int length;
    public Material cubeMaterial;
    public Material cornerMaterial;
    public PhysicMaterial physicMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = startingPoint;

        for (int i = 0; i < 4; i++)
        {
            int movement = (i < 2) ? 1 : -1;
            for (int j = 0; j < length; j++)
            {
                pos += ((i % 2 == 0) ? new Vector3(0, 0, movement) : new Vector3(movement, 0, 0));
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.GetComponent<Renderer>().material = cubeMaterial;
                wall.transform.SetPositionAndRotation(pos, Quaternion.Euler(0, i * 90, 0));
                wall.GetComponent<BoxCollider>().material = physicMaterial;
                
                wall.tag = "border";
            }
            pos += ((i % 2 == 0) ? new Vector3(0, 0, movement) : new Vector3(movement, 0, 0));
            GameObject corner = GameObject.CreatePrimitive(PrimitiveType.Cube);
            corner.GetComponent<Renderer>().material = cornerMaterial;
            corner.transform.SetPositionAndRotation(pos, Quaternion.Euler(0, (i + 2) * 90, 0));
            corner.GetComponent<BoxCollider>().material = physicMaterial;
            corner.tag = "border";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
