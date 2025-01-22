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
    public Sprite range;

    private Sprite normalSprite;
    private Sprite hoveredSprite;
    private GameObject rangeRenderer;

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

    private void Start()
    {
        rangeRenderer = new GameObject("Host Range Renderer");
        rangeRenderer.AddComponent<SpriteRenderer>();
        rangeRenderer.GetComponent<SpriteRenderer>().sprite = range;
        rangeRenderer.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 50);
        rangeRenderer.GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(90, 0, 0);
        rangeRenderer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rangeRenderer.transform.position = transform.position + new Vector3(0, -0.1f, 0);

        if (Input.GetMouseButtonDown(0) && selected && !held)
        {
            selected = false;
            GetComponent<SpriteRenderer>().sprite = normalSprite;
            if (!host.Manager.globalManager.GlobalRangeRender)
                host.RangeRendered = false;
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
            if (!host.Manager.globalManager.GlobalRangeRender)
                host.RangeRendered = false;
        }

        if ((host.Manager.globalManager.GlobalRangeRender || host.RangeRendered) && host.Infected)
        {
            rangeRenderer.SetActive(true);
        }
        else
        {
            rangeRenderer.SetActive(false);
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
            host.RangeRendered = true;
            
            GetComponent<SpriteRenderer>().sprite = hoveredSprite;
        }
    }

    private void OnMouseExit()
    {
        if (!selected)
            GetComponent<SpriteRenderer>().sprite = normalSprite;
    }
}
