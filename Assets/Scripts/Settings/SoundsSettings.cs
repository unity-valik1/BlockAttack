using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsSettings : MonoBehaviour
{
    AudioSource audioSource;

    public int _isActiveSounds = 1;


    [SerializeField] private GameObject _blockSounds;


    [SerializeField] private AudioClip audioClipsButton;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        LoadSound();
        IsActiveSounds();
    }

    private void IsActiveSounds()
    {
        if (_isActiveSounds == 1)
        {
            _blockSounds.SetActive(false);
        }
        else
        {
            _blockSounds.SetActive(true);
        }
    }
    public void ButtonSounds()
    {
        if (_isActiveSounds == 1)
        {
            audioSource.Stop();
            _isActiveSounds = 0;
            _blockSounds.SetActive(true);
        }
        else
        {
            audioSource.Play();
            _isActiveSounds = 1;
            _blockSounds.SetActive(false);
        }
        PlaySoundButton();
        SaveSound();
    }

    public void PlaySoundButton()
    {
        if (_isActiveSounds == 1)
        {
            audioSource.clip = audioClipsButton;
            audioSource.Play();
        }
    }

    public void SaveSound()
    {
        PlayerPrefs.SetInt("_isActiveSounds", _isActiveSounds);
        PlayerPrefs.Save();
    }
    public void LoadSound()
    {
        if (PlayerPrefs.HasKey("_isActiveSounds"))
        {
            _isActiveSounds = PlayerPrefs.GetInt("_isActiveSounds");
        }
    }
}
