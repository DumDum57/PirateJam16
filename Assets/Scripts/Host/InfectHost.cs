using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfectHost : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite hoveredSprite;

    private bool selected = false;
    private bool held = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selected && !held)
        {
            selected = false;
            GetComponent<SpriteRenderer>().sprite = normalSprite;
            Debug.Log("sex");
        }
        else if (!Input.GetMouseButtonDown(0) && held)
        {
            held = false;
        }
    }

    private void OnMouseOver()
    {
        if (!selected)
            GetComponent<SpriteRenderer>().sprite = hoveredSprite;

        if (Input.GetMouseButtonDown(0) && !selected && !held)
        {
            selected = true;
            held = true;
            GetComponent<SpriteRenderer>().sprite = hoveredSprite;
        }
    }

    private void OnMouseExit()
    {
        if (!selected)
            GetComponent<SpriteRenderer>().sprite = normalSprite;
    }
}
