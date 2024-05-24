using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        Debug.Log("Вы запустили обычную игру!");
        SceneManager.LoadScene("LobbyScene"); 
        // SceneManager.LoadScene("Scenes/GameScene");
    }
    
    public void PlayFreeGame()
    {
        Debug.Log("Вы запустили FreeGame!");
        SceneManager.LoadScene("FreeGame");; 
        // SceneManager.LoadScene("Scenes/GameScene");
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Debug.Log("Игра закрывается!");
        Application.Quit();
    }
}
