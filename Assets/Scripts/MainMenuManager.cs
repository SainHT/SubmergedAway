using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject controls;

    public void StartAdventure()
    {
        mainMenu.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(true);
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Movement");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
        controls.SetActive(false);
    }

    public void BackToMain()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (credits.activeSelf || controls.activeSelf))
        {
            BackToMain();
        }
    }
}
