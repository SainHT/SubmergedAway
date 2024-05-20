using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        print("Start Game");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Movement");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
