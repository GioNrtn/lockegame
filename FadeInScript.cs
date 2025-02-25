using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScript : MonoBehaviour
{
    public Animator fanim;
    // Start is called before the first frame update
    void Awake()
    {
        fanim = GameObject.Find("Transition").GetComponent<Animator>();
        //fanim.Play(""FadeIn)
    }

    
}
