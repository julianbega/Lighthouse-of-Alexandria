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
    //  public AK.Wwise.RTPC rtpc
    void Start()
    {
        sfxSlider.value = VolumeManager.instanceVolumeManager.GetSFXVolume();
        musicSlider.value = VolumeManager.instanceVolumeManager.GetMusicVolume();
    }

    void LateUpdate()
    {
        AkSoundEngine.SetRTPCValue("volume_music", musicSlider.value);
        AkSoundEngine.SetRTPCValue("volume_sfx", sfxSlider.value);
        VolumeManager.instanceVolumeManager.SetMusicVolume(musicSlider.value);
        VolumeManager.instanceVolumeManager.SetSFXVolume(sfxSlider.value);
        // rtpc.SetGlobalValue(volume_master,)
    }

    public void ActivateSettingsPanel()
    {
        settingsPanel.gameObject.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.gameObject.SetActive(false);
    }
}
