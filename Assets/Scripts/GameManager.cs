using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int _playerBestScore;
    public int _playerCoins;
    public int _playerArmor;
    public int _playerBomb;
    public int _playerPick;
    public string _playerName;

    private void Awake()
    {
        InitPlayerPrefs();
    }
    private void InitPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("_playerBestScore"))
        {
            _playerBestScore = PlayerPrefs.GetInt("_playerBestScore");

        }
        if (PlayerPrefs.HasKey("_playerCoins"))
        {
            _playerCoins = PlayerPrefs.GetInt("_playerCoins");

        }
        if (PlayerPrefs.HasKey("_playerArmor"))
        {
            _playerArmor = PlayerPrefs.GetInt("_playerArmor");

        }
        if (PlayerPrefs.HasKey("_playerBomb"))
        {
            _playerBomb = PlayerPrefs.GetInt("_playerBomb");
        }
        if (PlayerPrefs.HasKey("_playerPick"))
        {
            _playerPick = PlayerPrefs.GetInt("_playerPick");
        }
        if (PlayerPrefs.HasKey("_playerName"))
        {
            _playerName = PlayerPrefs.GetString("_playerName");

        }
    }

    public void SaveAllPlayerPrefs()
    {
        SavePlayerPrefsBestScore();
        SavePlayerPrefsCoins();
        SavePlayerPrefsArmor();
        SavePlayerPrefsBomb();
        SavePlayerPrefsPick();
        SavePlayerPrefsName();
    }

    public void SavePlayerPrefsBestScore()
    {
        PlayerPrefs.SetInt("_playerBestScore", _playerBestScore);
        PlayerPrefs.Save();
    }
    public void SavePlayerPrefsCoins()
    {
        PlayerPrefs.SetInt("_playerCoins", _playerCoins);
        PlayerPrefs.Save();
    }
    public void SavePlayerPrefsArmor()
    {
        PlayerPrefs.SetInt("_playerArmor", _playerArmor);
        PlayerPrefs.Save();
    }
    public void SavePlayerPrefsBomb()
    {
        PlayerPrefs.SetInt("_playerBomb", _playerBomb);
        PlayerPrefs.Save();
    }
    public void SavePlayerPrefsPick()
    {
        PlayerPrefs.SetInt("_playerPick", _playerPick);
        PlayerPrefs.Save();
    }
    public void SavePlayerPrefsName()
    {
        PlayerPrefs.SetString("_playerName", _playerName);
        PlayerPrefs.Save();
    }
}
