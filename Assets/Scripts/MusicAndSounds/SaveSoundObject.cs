using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObject : MonoBehaviour
{
    public static SoundObject instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) {
            DestroyImmediate(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }
}