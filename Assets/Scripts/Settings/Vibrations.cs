using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrations : MonoBehaviour
{
    SoundsSettings soundsSettings;

    public int _isActiveVibrations = 1;
    [SerializeField] private GameObject _blockVibrations;
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        soundsSettings = FindObjectOfType<SoundsSettings>();
    }
    private void Start()
    {
        LoadVibrations();
        IsActiveVibrations();
    }
    private void IsActiveVibrations()
    {
        if (_isActiveVibrations == 1)
        {
            _blockVibrations.SetActive(false);
        }
        else
        {
            _blockVibrations.SetActive(true);
        }
    }
    public void ButtonVibrations()
    {
        if (_isActiveVibrations == 1)
        {
            _isActiveVibrations = 0;
            _blockVibrations.SetActive(true);
        }
        else
        {
            _isActiveVibrations = 1;
            Vibration();
            _blockVibrations.SetActive(false);
        }
        soundsSettings.PlaySoundButton();
        SaveVibrations();
    }
    public void SaveVibrations()
    {
        PlayerPrefs.SetInt("_isActiveVibrations", _isActiveVibrations);
        PlayerPrefs.Save();
    }
    public void LoadVibrations()
    {
        if (PlayerPrefs.HasKey("_isActiveVibrations"))
        {
            _isActiveVibrations = PlayerPrefs.GetInt("_isActiveVibrations");
        }
    }
    public void Vibration()
    {
        if(_isActiveVibrations == 1)
        {
            Handheld.Vibrate();
        }
    }
}
