using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    static public VolumeManager instanceVolumeManager;
    static public VolumeManager Get { get { return instanceVolumeManager; } }

    public float musicVolume;
    public float sfxVolume;

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
        Debug.Log("valor que llega desde UISettings a Music: " + value);
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
}
