using Assets.Scripts.Host;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfectHost : MonoBehaviour
{
    private Host host;

    private bool selected = false;
    private bool held = false;

    public Sprite normal;
    public Sprite hovered;
    public Sprite infected;
    public Sprite infectedHovered;

    private Sprite normalSprite;
    private Sprite hoveredSprite;

    internal void Initilize(Host host)
    {
        this.host = host;

        if (host.Infected)
        {
            normalSprite = infected;
            hoveredSprite = infectedHovered;
        }
        else
        {
            normalSprite = normal;
            hoveredSprite = hovered;
        }

        GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selected && !held)
        {
            selected = false;
            GetComponent<SpriteRenderer>().sprite = normalSprite;
        }
        else if (!Input.GetMouseButtonDown(0) && held)
        {
            held = false;
        }

        if (Input.GetKey(KeyCode.Return) && !host.Infected && selected && host.Manager.globalManager.CheckInfectionRange(host, 1, out Host other))
        {
            host.Infected = true;
            normalSprite = infected;
            hoveredSprite = infectedHovered;
            selected = false;
            GetComponent<SpriteRenderer>().sprite = normalSprite;
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
