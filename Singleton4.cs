using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Singleton4 : MonoBehaviour
{
    private static Singleton4 _instance;

    public static Singleton4 Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
