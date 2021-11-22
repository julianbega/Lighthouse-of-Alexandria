using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    static public VolumeManager instanceVolumeManager;
    static public VolumeManager Get { get { return instanceVolumeManager; } }

    public float musicVolume;
    public float sfxVolume;
    public bool sfxOn;
    public bool musicOn;

    public bool fullScreen;
    private void Awake()
    {
        if (instanceVolumeManager != this && instanceVolumeManager != null)
            Destroy(gameObject);
        else
            instanceVolumeManager = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetMusicVolume(float value)
    {
        musicVolume = value;
    }

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }

    public void SetMusicOn(bool value)
    {
        musicOn = value;
    }

    public void SetSFXOn(bool value)
    {
        sfxOn = value;
    }

    public bool GetMusicOn()
    {
        return musicOn;
    }

    public bool GetSFXOn()
    {
        return sfxOn;
    }


    public bool GetFullScren()
    {
        return fullScreen;
    }

    public void SetFullScren(bool value)
    {
        fullScreen = value;
    }

    private void Update()
    {
        AkSoundEngine.SetRTPCValue("volume_music", musicVolume);
        AkSoundEngine.SetRTPCValue("volume_sfx", sfxVolume);
    }
}
