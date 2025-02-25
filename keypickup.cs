using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypickup : MonoBehaviour
{
    
    public bool IsPickedUp;
    void Awake()
    {
        IsPickedUp = false;
        Debug.Log(IsPickedUp);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            StartCoroutine(PickUpKey());
        }
    }

    IEnumerator PickUpKey()
    { 
        yield return new WaitForSecondsRealtime(0);
        IsPickedUp = true;
        
        Destroy(this.gameObject);
        


    }
    void Update()
    {
       
    }

}
