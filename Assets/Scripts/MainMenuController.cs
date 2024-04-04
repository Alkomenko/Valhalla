using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        Debug.Log("Игра начинается!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // SceneManager.LoadScene("Scenes/GameScene");
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Debug.Log("Игра закрывается!");
        Application.Quit();
    }
}
