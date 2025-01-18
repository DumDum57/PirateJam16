using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public Vector3 startingPoint;
    public int length;
    public Material cubeMaterial;
    public Material cornerMaterial;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> walls = new();
        Vector3 pos = startingPoint;

        for (int i = 0; i < 4; i++)
        {
            int movement = (i < 2) ? 1 : -1;
            for (int j = 0; j < length; j++)
            {
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.GetComponent<Renderer>().material = cubeMaterial;
                pos += ((i % 2 == 0) ? new Vector3(0, 0, movement) : new Vector3(movement, 0, 0));
                wall.transform.position = pos;
            }
            pos += ((i % 2 == 0) ? new Vector3(0, 0, movement) : new Vector3(movement, 0, 0));
            GameObject corner = GameObject.CreatePrimitive(PrimitiveType.Cube);
            corner.GetComponent<Renderer>().material = cornerMaterial;
            corner.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
