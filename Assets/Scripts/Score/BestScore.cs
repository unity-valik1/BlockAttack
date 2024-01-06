using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BestScore : MonoBehaviour
{
    Score score;
    [SerializeField] private TMP_Text _textBestScore;

    public int _playerBestScore;

    private void Awake()
    {
        Init();
    }
    private void Start()
    {
        LoadBestScore();
    }
    private void Init()
    {
        score = FindObjectOfType<Score>();
    }
    public void UpdateBestScore()
    {
        if (_playerBestScore < score._currentScore)
        {
            _playerBestScore = score._currentScore;
            _textBestScore.text = _playerBestScore.ToString();
            SaveBestScore();
        }
    }
    public void SaveBestScore()
    {
        PlayerPrefs.SetInt("_playerBestScore", _playerBestScore);
        PlayerPrefs.Save();
    }
    public void LoadBestScore()
    {
        if (PlayerPrefs.HasKey("_playerBestScore"))
        {
            _playerBestScore = PlayerPrefs.GetInt("_playerBestScore");
            _textBestScore.text = _playerBestScore.ToString();
        }
    }
}
