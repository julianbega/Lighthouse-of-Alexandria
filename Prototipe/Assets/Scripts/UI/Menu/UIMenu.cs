using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public TMP_Text versionText;
    private uint menuMusicID;
    void Start()
    {
        versionText.text = "V" + Application.version;
        menuMusicID = AkSoundEngine.PostEvent("play_music_menu", this.gameObject);
    }

    private void OnDisable()
    {
        LeaveMenu();
    }

    public void LeaveMenu()
    {
        AkSoundEngine.StopPlayingID(menuMusicID);
    }
}
