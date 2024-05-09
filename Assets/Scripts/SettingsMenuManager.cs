using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenuManager : MonoBehaviour
{
    // Reference the graphics dropdown
    public TMP_Dropdown graphicsDropdown;

    // Reference the audio sliders
    public Slider masterVolumeSlider, bgmVolumeSlider, sfxVolumeSlider;

    // Reference the audio mixer
    public AudioMixer mainAudioMixer;

    // Reference the settings popup
    public GameObject settingsPopup;

    public void OpenSettings()
    {
        // Set the settings popup active
        settingsPopup.SetActive(true);
    }

    public void CloseSettings()
    {
        // Set the settings popup inactive
        settingsPopup.SetActive(false);
    }

    public void ChangeGraphicsQuality()
    {
        // Set the quality level to the dropdown value
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }

    public void ChangeMasterVolume()
    {
        // Set the master volume to the slider value
        mainAudioMixer.SetFloat("MasterVolume", masterVolumeSlider.value);
    }

    public void ChangeBGMVolume()
    {
        // Set the BGM volume to the slider value
        mainAudioMixer.SetFloat("BGMVolume", bgmVolumeSlider.value);
    }

    public void ChangeSFXVolume()
    {
        // Set the SFX volume to the slider value
        mainAudioMixer.SetFloat("SFXVolume", sfxVolumeSlider.value);
    }
    // First frame
    void Start()
    {
        
    }

    // Every frame
    void Update()
    {
        
    }
}
