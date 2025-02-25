using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptenabler : MonoBehaviour
{
    public GameObject GC;
    public GameObject WC;
    public GameObject Omni;
    public OmniScript omniscript;
    
       
    // Start is called before the first frame update
    void Start()
    {
        Omni = GameObject.Find("Omni");
        omniscript = Omni.GetComponent<OmniScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (omniscript.WindowReady == true)
        {
            WC.GetComponent<NRWindowCollider>().enabled = true;
        }
        if (omniscript.GrassReady == true)
        {
            GC.GetComponent<GrassCollider>().enabled = true;
        }
    }
}
