using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Singleton2 : MonoBehaviour
{
    private static Singleton2 _instance;

    public static Singleton2 Instance { get { return _instance; } }


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
