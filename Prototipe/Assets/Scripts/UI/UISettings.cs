using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    //public float volumeMaster;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Toggle sfxToggle;
    public Toggle musicToggle;
    public Toggle fullScreenToggle;
    //  public AK.Wwise.RTPC rtpc
    void Start()
    {
        if (VolumeManager.instanceVolumeManager != null)
        {
            sfxSlider.value = VolumeManager.instanceVolumeManager.GetSFXVolume();
            musicSlider.value = VolumeManager.instanceVolumeManager.GetMusicVolume();
            sfxToggle.isOn = VolumeManager.instanceVolumeManager.GetSFXOn();
            musicToggle.isOn = VolumeManager.instanceVolumeManager.GetMusicOn();
            fullScreenToggle.isOn = VolumeManager.instanceVolumeManager.GetFullScren();
        }
    }

    void LateUpdate()
    {
        if (VolumeManager.instanceVolumeManager != null)
        {
            VolumeManager.instanceVolumeManager.SetMusicVolume(musicSlider.value);
            VolumeManager.instanceVolumeManager.SetSFXVolume(sfxSlider.value);
            VolumeManager.instanceVolumeManager.SetSFXOn(sfxToggle.isOn);
            VolumeManager.instanceVolumeManager.SetMusicOn(musicToggle.isOn);
            VolumeManager.instanceVolumeManager.SetFullScren(fullScreenToggle.isOn);
            // rtpc.SetGlobalValue(volume_master,)
        }
    }

    public void ActivateSettingsPanel()
    {
        settingsPanel.gameObject.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.gameObject.SetActive(false);
    }

    public void SFXMute()
    {
        if (sfxToggle.isOn)
        {
            AkSoundEngine.SetState("sfxmute", "off");
        }
        else
        {
            AkSoundEngine.SetState("sfxmute", "on");
        } 
    }
    public void MusicMute()
    {
        if (musicToggle.isOn)
        {
            Debug.Log("MusicaOn ");
            AkSoundEngine.SetState("musicmute", "off");
        }
        else
        {
            Debug.Log("MusicaOff ");
            AkSoundEngine.SetState("musicmute", "on");
        }        
    }

    public void FullScreen()
    {
        if (fullScreenToggle.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }
}
