using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSettings : MonoBehaviour
{
    AudioSource audioSource;
    SoundsSettings soundsSettings;

    [Header("Музыка")]
    [Tooltip("Музыка")][SerializeField] private int _isActiveMusic = 1;

    [SerializeField] private GameObject _blockMusic;

    [SerializeField] private AudioClip audioClipsMenu;
    [SerializeField] private AudioClip audioClipsGame;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        audioSource = GetComponent<AudioSource>();
        soundsSettings =FindObjectOfType<SoundsSettings>();
    }

    private void Start()
    {
        LoadMusic();
        IsActiveMusic();
    }
    private void IsActiveMusic()
    {
        if (_isActiveMusic == 1)
        {
            audioSource.Play();
            _blockMusic.SetActive(false);
        }
        else
        {
            audioSource.Stop();
            _blockMusic.SetActive(true);
        }
    }
    public void ButtonMusic()
    {
        if (_isActiveMusic == 1)
        {
            audioSource.Stop();
            _isActiveMusic = 0;
            _blockMusic.SetActive(true);
        }
        else
        {
            audioSource.Play();
            _isActiveMusic = 1;
            _blockMusic.SetActive(false);
        }
        soundsSettings.PlaySoundButton();
        SaveMusic();
    }

    public void PlayAudioClipsMenu()
    {
        if (_isActiveMusic == 1)
        {
            audioSource.clip = audioClipsMenu;
            audioSource.Play();
        }
    }
    public void PlayAudioClipsGame()
    {
        if (_isActiveMusic == 1)
        {
            audioSource.clip = audioClipsGame;
            audioSource.Play();
        }
    }

    public void SaveMusic()
    {
        PlayerPrefs.SetInt("_isActiveMusic", _isActiveMusic);
        PlayerPrefs.Save();
    }
    public void LoadMusic()
    {
        if (PlayerPrefs.HasKey("_isActiveMusic"))
        {
            _isActiveMusic = PlayerPrefs.GetInt("_isActiveMusic");
        }
    }
}
