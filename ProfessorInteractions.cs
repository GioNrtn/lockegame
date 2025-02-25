using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProfessorInteractions : MonoBehaviour
{
    public Animator panim;
    public Animator pdanim;
    public bool inputz;
    public KeyCode Z;
    //public bool IsOpen;
    public bool touching;
    public int talkcount;
    public Text dialoguetext;
    public int basen;
    public ProfessorScript counterscript;
    public GameObject Professor;
    public Sprite LeftSprite;
    public Sprite RightSprite;
    public SpriteRenderer prend;
    public Sprite ActiveSprite;
    public Sprite FrontSprite;
    public GameObject Omni;
    public OmniScript omniscript;

    //public GameObject RWC;
    //public NRWindowCollider aaaa;

    // Start is called before the first frame update
    void Awake()
    {
        talkcount = 0;
        panim = GameObject.Find("Professor").GetComponent<Animator>();
        pdanim = GameObject.Find("ProfessorDialogue").GetComponent<Animator>();
        inputz = false;
        touching = false;
        dialoguetext = GameObject.Find("Text").GetComponent<Text>();
        Omni = GameObject.Find("Omni");
        omniscript = Omni.GetComponent<OmniScript>();
        //aaaa = RWC.GetComponent<NRWindowCollider>();




        //IsOpen = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            talkcount = basen;
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
            talkcount = basen;
            pdanim.Play("TextBoxFadeOut");
            if (basen == 10)
            {
                prend.sprite = RightSprite;

            }




        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(RWC.GetComponent<NRWindowCollider>().enabled);
        counterscript = Professor.GetComponent<ProfessorScript>();
        basen = counterscript.professorcounter * 10;
        //Debug.Log("basen " + basen);
        //Debug.Log("talkcount" + talkcount);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            inputz = true;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            inputz = false;

        }
        if (touching == true && inputz == true)
        {

            StartCoroutine(DialogueStart());
            
        }
        if (basen == 0)
        {
            ActiveSprite = FrontSprite;
        }
        if (talkcount == 10)
        {
            ActiveSprite = LeftSprite;
        }
        if(basen == 10 && talkcount < 10)
        {
            ActiveSprite = LeftSprite;
        }



        //Debug.Log(inputz);
    }





    IEnumerator DialogueStart()
    {
        yield return new WaitForSecondsRealtime(0);
        //talkcount += 1;
        //Debug.Log("CoroutineStarted");
        //Debug.Log("talkc"talkcount);

        if (talkcount == 0 && inputz == true)
        {
            Debug.Log("Bruh");
            dialoguetext.text = "Hello There!";
            pdanim.Play("TextBoxFadeIn");
            yield return new WaitForSecondsRealtime(1);
            talkcount = 1;

        }
        if (talkcount == 1 && inputz == true)
        {
            dialoguetext.text = "Welcome to the Castle.";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 2;


        }
        if (talkcount == 2 && inputz == true)
        {
            dialoguetext.text = "So you took shelter here too eh?";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 3;


        }
        if (talkcount == 3 && inputz == true)
        {
            dialoguetext.text = "I've been here about a day now";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 4;

            //Debug.Log("Why");

        }
        if (talkcount == 4 && inputz == true)
        {
            dialoguetext.text = "Please dont hesitate to ask me anything if you're confused";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 5;
            

            //Debug.Log("Why");

        }
        if (talkcount == 5 && inputz == true)
        {
            pdanim.Play("TextBoxFadeOut");
            yield return new WaitForSecondsRealtime(1);
            talkcount = basen;

        }
        if (talkcount == 10 && inputz == true)
        {
            Debug.Log("bruh22");
            dialoguetext.text = "The architecture in this place is very peculiar";
            pdanim.Play("TextBoxFadeIn");
            yield return new WaitForSecondsRealtime(1);
            talkcount = 11;
            
        }
        if (talkcount == 11 && inputz == true)
        {
            ActiveSprite = RightSprite;
            
            prend.sprite = RightSprite;
            yield return new WaitForSecondsRealtime(0.55f);
            dialoguetext.text = "Ah, I see you've gone into the north room.";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 12;

        }
        if (talkcount == 12 && inputz == true)
        {
            //prend.sprite = RightSprite;
            dialoguetext.text = "I don't usually get frightened easily,";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 13;

        }
        if (talkcount == 13 && inputz == true)
        {
            //prend.sprite = RightSprite;
            dialoguetext.text = "But I only managed to explore a small part of the room";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 14;

        }
        if (talkcount == 14 && inputz == true)
        {
            //prend.sprite = RightSprite;
            dialoguetext.text = "Before I heard the most frightening noise coming from one of the windows and ran back here!.";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 15;
            omniscript.WindowReady = true;
            //RWC.GetComponent<NRWindowCollider>().enabled = true;
           
        }
        if (talkcount == 15 && inputz == true)
        {
            pdanim.Play("TextBoxFadeOut");
            ActiveSprite = LeftSprite;
            prend.sprite = LeftSprite;

            yield return new WaitForSecondsRealtime(1);
            talkcount = basen;
        }
    }

}
