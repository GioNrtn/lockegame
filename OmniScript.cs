using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OmniScript : MonoBehaviour
{
    public GameObject Omni;
    public bool WindowReady;
    public bool GrassReady;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(Omni);
        WindowReady = false;
        GrassReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
