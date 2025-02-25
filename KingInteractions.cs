using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KingInteractions : MonoBehaviour
{
    public Animator gkanim;
    public Animator gkdanim;
    public bool inputz;
    public KeyCode Z;
    //public bool IsOpen;
    public bool touching;
    public int talkcount;
    public Text dialoguetext;
    public int basen;
    //public ProfessorScript counterscript;
    //public GameObject Professor;
    public Sprite LeftSprite;
    public Sprite RightSprite;
    public GameObject Omni;
    public OmniScript omniscript;
    //public GameObject GC;
    //public SpriteRenderer prend;
    //public Sprite ActiveSprite;
    //public Sprite FrontSprite;

    // Start is called before the first frame update
    void Awake()
    {
        talkcount = 0;
        gkanim = GameObject.Find("GhostKing").GetComponent<Animator>();
        gkdanim = GameObject.Find("GhostKingDialogue").GetComponent<Animator>();
        inputz = false;
        touching = false;
        dialoguetext = GameObject.Find("GKText").GetComponent<Text>();
        Omni = GameObject.Find("Omni");
        omniscript = Omni.GetComponent<OmniScript>();
        

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
            gkdanim.Play("GKDFO");
            




        }
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
        if (touching == true && inputz == true)
        {

            StartCoroutine(DialogueStart());
            
        }
       


        //Debug.Log(inputz);
    }





    IEnumerator DialogueStart()
    {
        yield return new WaitForSecondsRealtime(0);
        //talkcount += 1;
        Debug.Log("CoroutineStarted");
        //Debug.Log("talkc"talkcount);

        if (talkcount == 0 && inputz == true)
        {
            Debug.Log("Bruh");
            dialoguetext.text = "Ah Horace, you're finally here!";
            gkdanim.Play("GKDFI");
            yield return new WaitForSecondsRealtime(1);
            talkcount = 1;

        }
        if (talkcount == 1 && inputz == true)
        {
            dialoguetext.text = "What do you mean that's not your name? Did you hit your head or something? ";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 2;


        }
        if (talkcount == 2 && inputz == true)
        {
            dialoguetext.text = "You must be the most inept servant in this entire castle!";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 3;


        }
        if (talkcount == 3 && inputz == true)
        {
            dialoguetext.text = "Anyway, I told you to deal with that pestilent ivy days ago!";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 4;
            //GC.GetComponent<GrassCollider>().enabled = true;
            //Debug.Log(GC.GetComponent<GrassCollider>().enabled);
            omniscript.GrassReady = true;

            //Debug.Log("Why");

        }
        if (talkcount == 4 && inputz == true)
        {
            dialoguetext.text = "Its destroying my precious archway!";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 5;

            //Debug.Log("Why");

        }if (talkcount == 5 && inputz == true)
        {
            dialoguetext.text = "What kind of king would I be if I didn't mantain my castle??";
            yield return new WaitForSecondsRealtime(1);
            talkcount = 6;

            //Debug.Log("Why");

        }
        if (talkcount == 6 && inputz == true)
        {
            gkdanim.Play("GKDFO");
            yield return new WaitForSecondsRealtime(1);
            talkcount = basen;

  
        }
    }

}
