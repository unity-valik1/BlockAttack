using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBrokenHeart : MonoBehaviour
{
    SoundsSettings soundsSettings;
    AudioSource audioSource;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        soundsSettings = FindObjectOfType<SoundsSettings>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundBrokenHeart()
    {
        if (soundsSettings._isActiveSounds == 1)
        {
            audioSource.Play();
        }
    }
}
