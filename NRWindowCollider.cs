using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NRWindowCollider: MonoBehaviour
{
    public bool touching;
    public KeyCode Z;
    public Sprite key;
    public bool inputz;
    public bool InteractionOver;
    public int InteractCount;
    public Animator wanim;
    public int next;
    public GrassCollider GCScript;
    public Text WindowText;
    public GameObject Window;
    public GameObject GC;
    public bool started;
    //public bool InteractionOver;
    
    // Start is called before the first frame update
    void Awake()
    {
        //WindowText = Window.GetComponent<WText>();
        next = 5;
        InteractionOver = false;
        InteractCount = 0;
        wanim = GameObject.Find("WindowMessages").GetComponent<Animator>();
        GCScript = GC.GetComponent<GrassCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("GotBar =" + GCScript.GotBar);
        if (GCScript.GotBar == true) 
        {
            next = 2;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            inputz = true;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            inputz = false;

        }
        if (InteractionOver == false)
        {
            //Debug.Log("AguaSUIII1");
            if (touching == true && inputz == true)
            {
                Debug.Log("AguaSUIII2");

                StartCoroutine(WindowInteract());

            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //talkcount = basen;
            touching = true;
            //Debug.Log("Touch me baby");




        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            touching = false;
            //Debug.Log("all alone");
            StartCoroutine(EndWindowInteract());
           
            




        }
    }
    IEnumerator WindowInteract()
    {
        started = true;
        // Debug.Log("AguaSUIII3");
        if (InteractCount == 0 && inputz == true)
        {
            WindowText.text = "There is a gap in the window, causing an eerie whistiling noise.";
            wanim.Play("WFI");
            yield return new WaitForSecondsRealtime(0.5f);
            InteractCount = next;
            Debug.Log("Interact =" + InteractCount);

        }
        if (InteractCount == 2 && inputz == true)
        {
            WindowText.text = "You place the metal bar in the window.";
            yield return new WaitForSecondsRealtime(0.5f);
            InteractCount = 3;
        }
        if (InteractCount == 3 && inputz == true)
        {
            WindowText.text = "The noise has stopped!";
            yield return new WaitForSecondsRealtime(0.5f);
            InteractCount = 5;
            InteractionOver = true;
        }
        if (InteractCount == 5 && inputz == true)
        {
            StartCoroutine(EndWindowInteract());


        }




    }
    IEnumerator EndWindowInteract()
    {
        if (started == true)
        {
            wanim.Play("WFO");
            yield return new WaitForSecondsRealtime(0.5f);
            if (InteractionOver == false)
            {
                InteractCount = 0;
            }
            if (InteractionOver == true)
            {
                InteractCount = 10;
            }
            started = false;
        }
    }
}
