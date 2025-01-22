using Assets.Scripts.Host;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostManager : MonoBehaviour
{
    private Host host;

    public GlobalHostManager globalManager;

    // Start is called before the first frame update
    void Start()
    {
        host = new(1, this);

        gameObject.GetComponent<InfectHost>().Initilize(host);
        gameObject.GetComponent<HostMovement>().Inizialize(host);
        globalManager.AddHost(host);
    }
}
