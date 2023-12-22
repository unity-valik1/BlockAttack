using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BestScore : MonoBehaviour
{
    Score score;
    [SerializeField] private TMP_Text _textBestScore;

    public int _bestScore;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        score = FindObjectOfType<Score>();
    }
    public void UpdateBestScore()
    {
        if (_bestScore < score._currentScore)
        {
            _bestScore = score._currentScore;
            _textBestScore.text = _bestScore.ToString();
        }
    }
}
