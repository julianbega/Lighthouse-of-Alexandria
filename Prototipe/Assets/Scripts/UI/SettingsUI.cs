using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    private uint menuMusicID;
    // Start is called before the first frame update
    void Start()
    {
        menuMusicID = AkSoundEngine.PostEvent("play_music_menu", this.gameObject);
    }

   public void exitSettings()
    {
        AkSoundEngine.StopPlayingID(menuMusicID);
    }
}
