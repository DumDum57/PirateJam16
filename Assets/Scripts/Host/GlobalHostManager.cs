using Assets.Scripts.Host;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalHostManager : MonoBehaviour
{
    private List<Host> hosts = new();

    private bool globalRangeRender = false;
    internal bool GlobalRangeRender
    {
        get => globalRangeRender;
        set
        {
            if (value == true)
            {
                globalRangeRender = true;
                foreach (Host host in hosts)
                {
                    host.RangeRendered = true;
                }
            }
            else
            {
                globalRangeRender = false;
                foreach (Host host in hosts)
                {
                    host.RangeRendered = false;
                }
            }
        }
    }

    internal void AddHost(Host host)
    {
        hosts.Add(host);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GlobalRangeRender = !GlobalRangeRender;
        }
    }

    internal bool CheckInfectionRange(Host infecting, float range, out Host other)
    {
        float minDistance = range;
        Host minHost = null;
        foreach (Host host in hosts)
        {
            if (Vector3.Distance(infecting.Manager.gameObject.transform.position, host.Manager.transform.position) < minDistance && host.Infected)
            {
                minDistance = Vector3.Distance(infecting.Manager.gameObject.transform.position, host.Manager.transform.position);
                minHost = host;
            }
        }

        other = minHost;
        return minHost is not null;
    }
}
