using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InfectHost : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite hoveredSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().sprite = hoveredSprite;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = normalSprite;
    }
}
