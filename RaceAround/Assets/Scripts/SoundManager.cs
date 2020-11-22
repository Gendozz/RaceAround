using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource EffectsSource;
    
    [SerializeField]
    private AudioSource MusicSource;
    
    [SerializeField]
    private AudioMixer _audioMixer;

    [SerializeField]
    private float LowPitchRange = .95f;
    
    [SerializeField]
    private float HighPitchRange = 1.05f;
    
    public static SoundManager Instance = null;
	
    private void Awake()
    {
        if (Instance == null)
        {
            SoundManager.Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad (gameObject);
    }

    private void Start()
    {
        _audioMixer.SetFloat("musicVolume", -20f);
        _audioMixer.SetFloat("sfxVolume", -20f);
    }
    
    public void MusicVolume(float sliderValue)
    {
        _audioMixer.SetFloat("musicVolume", sliderValue);
    }
    
    public void SfxVolume(float sliderValue)
    {
        _audioMixer.SetFloat("sfxVolume", sliderValue);
    }

    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

        EffectsSource.pitch = randomPitch;
        EffectsSource.clip = clips[randomIndex];
        EffectsSource.Play();
    }
}
