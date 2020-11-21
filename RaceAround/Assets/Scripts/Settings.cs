using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    private bool isFullScreen = false;
    
    public AudioMixer am;

    private void Start()
    {
        am.SetFloat("musicVolume", -20f);
    }

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("musicVolume", sliderValue);
    }

    public void SfxVolume(float sliderValue)
    {
        am.SetFloat("sfxVolume", sliderValue);
    }
    
}
