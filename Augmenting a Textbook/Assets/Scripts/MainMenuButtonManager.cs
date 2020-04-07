using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour
{

    private GameObject mainMenu;
    private GameObject helpMenu;

    public void Start()
    {
        mainMenu = GameObject.Find("MainMenu");
        helpMenu = GameObject.Find("HelpMenu");

        helpMenu.SetActive(false);
    }

    public void LoadCameraScene()
    {
        SceneManager.LoadScene("Camera");
    }

    public void ShowHelp()
    {
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
    }

    public void HideHelp()
    {
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
    }
}
