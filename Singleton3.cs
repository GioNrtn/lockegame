using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Singleton3 : MonoBehaviour
{
    private static Singleton3 _instance;

    public static Singleton3 Instance { get { return _instance; } }


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
