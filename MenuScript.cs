using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button button;
    public KeyCode Z;
    public KeyCode P;
    public Animator mfanim;
    public Animator wanim;
    public Animator banim;
    public GameObject ControlsCanvas;
    public GameObject StartCanvas;
    public bool readyforz1;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnButtonPress()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH");
        StartCoroutine(FIFO());
    }


    // Update is called once per frame
    void Update()
    {
        
        //button.onClick.AddListener(Clicked);
        if (readyforz1 == true)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                StartCoroutine(GoToGame());
            }

        }
    }
    void Clicked()
    {
        Debug.Log("Clicked");
        StartCoroutine(FIFO());
    }
    IEnumerator FIFO()
    {
        mfanim.Play("MMFadeOut");
        yield return new WaitForSecondsRealtime(0.7f);
        //code to remove menuscreen
        wanim.Play("WallDelete");
        banim.Play("ButtonDelete");
        Debug.Log("Contunuing");
        mfanim.Play("MMFadeIn");
        readyforz1 = true;

    }
    IEnumerator GoToGame()
    {
        mfanim.Play("MMFadeOut");
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("EntryRoom");
    }

}
