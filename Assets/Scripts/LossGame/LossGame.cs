using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossGame : MonoBehaviour
{
    UILogicsGame uILogicsGame;
    Health health;
    BestScore bestScore;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        uILogicsGame = FindObjectOfType<UILogicsGame>();
        health = FindObjectOfType<Health>();
        bestScore = FindObjectOfType<BestScore>();
    }
    public void Loos()
    {
        uILogicsGame.LossGamePanel();
        health.UpdateHealth();
        bestScore.UpdateBestScore();
    }
}
