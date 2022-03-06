using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSounds : MonoBehaviour
{
    private uint levelSoundsID;

    void Start()
    {
        AkSoundEngine.StopPlayingID(levelSoundsID);
        LevelManager.ExecutelevelSounds += ExecuteSound;
    }

    private void OnDisable()
    {
        LevelManager.ExecutelevelSounds -= ExecuteSound;
        AkSoundEngine.StopPlayingID(levelSoundsID);
    }

    public void ExecuteSound(string sound)
    {
        levelSoundsID = AkSoundEngine.PostEvent(sound, gameObject);
    }
}
