using Assets.Scripts.Host;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalHostManager : MonoBehaviour
{
    private List<Host> hosts = new();

    internal void AddHost(Host host)
    {
        hosts.Add(host);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal bool CheckInfectionRange(Host infecting, float range, out Host other)
    {
        float minDistance = 2f;
        Host minHost = null;
        foreach (Host host in hosts)
        {
            if (Vector3.Distance(infecting.Manager.gameObject.transform.position, host.Manager.transform.position) < minDistance * range)
            {
                minDistance = Vector3.Distance(infecting.Manager.gameObject.transform.position, host.Manager.transform.position);
                minHost = host;
            }
        }

        other = minHost;
        return minHost is not null;
    }
}
