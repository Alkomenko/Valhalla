using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    
    // Сохраняем обьект при переходе со сцены на сцену
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
