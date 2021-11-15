using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    static public ScenesManager instanceScenesManager;

    static public ScenesManager Instance { get { return instanceScenesManager; } }

    private void Awake()
    {
        if (instanceScenesManager != null && instanceScenesManager != this)
            Destroy(this.gameObject);
        else
            instanceScenesManager = this;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ChangeSceneWithWaitSeconds(string scene)
    {
        StartCoroutine(WaitSecondsForChangeScene(2, scene));
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitSecondsForChangeScene(int seconds, string scene)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene);
        yield return null;
    }
}
