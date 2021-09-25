using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Prototype3");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
