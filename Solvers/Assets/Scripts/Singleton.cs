using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;
    public static T Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = FindObjectOfType<T>();
            if (transform.parent != null && transform.root != null) DontDestroyOnLoad(transform.root.gameObject);
            else DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
