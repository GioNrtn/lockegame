using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProfessorScript : MonoBehaviour
{
    public int professorcounter;
    public GameObject Professor;
    public Sprite CorrectSprite;
    public SpriteRenderer prend;
    public ProfessorInteractions spritescript;
    // Start is called before the first frame update
    void Awake()
    {
        Professor = GameObject.Find("Professor");
        professorcounter = 0;
    }
   

    // Update is called once per frame
    void Update()
    {
        spritescript = Professor.GetComponent<ProfessorInteractions>();
        Scene currentScene = SceneManager.GetActiveScene();
        CorrectSprite = spritescript.ActiveSprite;
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
        //Debug.Log("profcounter  " + professorcounter);
        //Debug.Log(sceneName);
        if (sceneName == "EntryRoom")
        {
            //Debug.Log("ifwork");
            if (professorcounter == 0)
            {
                //Debug.Log("SHouldmove");
                Professor.transform.position = new Vector2(-4, 5);
            }
            if (professorcounter == 1)
            {
                Professor.transform.position = new Vector2(-9.5f, 2);
                prend.sprite = CorrectSprite;
            }
        }
        else
        {
            Professor.transform.position = new Vector2(0, 20);
        }
    }
}
