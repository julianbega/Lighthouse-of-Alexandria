using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private uint sceneManagerMusicID;
    static public ScenesManager instanceScenesManager;

    static public ScenesManager instance { get { return instanceScenesManager; } }

    private void Awake()
    {
        if (instanceScenesManager != null && instanceScenesManager != this)
            Destroy(this.gameObject);
        else
            instanceScenesManager = this;
    }

    private void OnDisable()
    {
        StopMusic();
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);

        if (scene == "Settings")
            sceneManagerMusicID = AkSoundEngine.PostEvent("play_music_menu", this.gameObject);
        if (scene == "Credits")
            sceneManagerMusicID = AkSoundEngine.PostEvent("play_music_credits", this.gameObject);

    }

    public void ChangeSceneWithWaitSeconds(string scene)
    {
        StartCoroutine(WaitSecondsForChangeScene(2, scene));
    }

    public void GoToMainMenu()
    {
        GameManager.instance.PauseGame("unpause");
        sceneManagerMusicID = AkSoundEngine.PostEvent("play_music_menu", this.gameObject);
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

    public void StopMusic()
    {
        AkSoundEngine.StopPlayingID(sceneManagerMusicID);
    }

}
