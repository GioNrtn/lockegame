using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrassCollider : MonoBehaviour
{
    public bool touching;
    public KeyCode Z;
    public Sprite key;
    public bool inputz;
    public bool InteractionOver;
    public int InteractCount;
    public Animator ganim;
    public Text grasstext;
    public int next;
    public bool started;
    public bool GotBar;
    // Start is called before the first frame update
    void Awake()
    {
        //next = 5;
        InteractionOver = false;
        InteractCount = 0;
        //ganim = GameObject.Find("WindowMessages").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
                //Debug.Log("AguaSUIII2");

                StartCoroutine(GrassInteract());

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
            StartCoroutine(EndGrassInteract());
           
            




        }
    }
    IEnumerator GrassInteract()
    {
        started = true;
        // Debug.Log("AguaSUIII3");
        if (InteractCount == 0 && inputz == true)
        {
            Debug.Log("Grassshlid");
            grasstext.text = "The ivy on the archway has knocked down a piece of metal.";
            ganim.Play("GFI");
            yield return new WaitForSecondsRealtime(0.5f);
            InteractCount = 1;

        }
        if (InteractCount == 1 && inputz == true)
        {
            InteractionOver = true;
            grasstext.text = "Obtained the Metal Bar!";
            GotBar = true;
            yield return new WaitForSecondsRealtime(0.5f);
            InteractCount = 3;


        }
        if (InteractCount == 3 && inputz == true)
        {
            Debug.Log("Shouldfade1");
            StartCoroutine(EndGrassInteract());


        }




    }
    IEnumerator EndGrassInteract()
    {   
        if (started == true)
        {
            Debug.Log("Shouldfadeout");
            ganim.Play("GFO");
            yield return new WaitForSecondsRealtime(0.5f);
            if (InteractionOver == false)
            {
                InteractCount = 0;
            }
            else
            {
                InteractCount = 10;
            }
            started = false;
        }
    }
}
