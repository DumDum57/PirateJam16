using Assets.Scripts.Host;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostManager : MonoBehaviour
{
    private Host host;

    public GlobalHostManager globalManager;
    public bool startInfected;

    // Start is called before the first frame update
    void Start()
    {
        host = new(1, this);

        if (startInfected)
        {
            host.Infected = true;
        }

        gameObject.GetComponent<InfectHost>().Initilize(host);
        gameObject.GetComponent<HostMovement>().Inizialize(host);
        globalManager.AddHost(host);
        
    }
}
