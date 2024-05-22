using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public static bool PauseGame;
    public GameObject BackpackMenu;
    
    public void Pause()
    {
        if (Time.timeScale == 1f)
        {
            BackpackMenu.SetActive(true);
            Time.timeScale = 0f;
            PauseGame = true;
        }
        else if (Time.timeScale == 0f)
        {
            BackpackMenu.SetActive(false);
            Time.timeScale = 1f;
            PauseGame = true;
        }

    }
}