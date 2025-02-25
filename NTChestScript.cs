using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NTChestScript : MonoBehaviour
{
    public Animator canim;
    public bool inputz;
    public KeyCode Z;
    public bool IsOpen;
    public bool touching;

    // Start is called before the first frame update
    void Awake()
    {
        canim = GameObject.Find("ChestClosed").GetComponent<Animator>();
        inputz = false;
        touching = false;
        IsOpen = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            touching = true;
            Debug.Log("Touch me baby");
            
        
            

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            touching = false;
            Debug.Log("all alone");




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
        if (IsOpen == false)
        {
            if (touching == true && inputz == true)
            {

                StartCoroutine(OpenChest());

            }
        }


        //Debug.Log(inputz);
    }

    

    

    IEnumerator OpenChest()
    {
        yield return new WaitForSecondsRealtime(0);
        canim.Play("NTChestOpen");
        IsOpen = true;

    }
}
