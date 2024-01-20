using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bomb : MonoBehaviour
{
    GameManager gameManager;
    AnimCameraEffectBomb animCameraEffectBomb;
    BoomSmoke boomSmoke;
    DestroyAllBlocks destroyAllBlocks;
    ExplosionEffect explosionEffect;
    BombSound bombSound;
    UILogicTopBar uILogicTopBar;
    UILogicsGame uILogicsGame;
    DatabaseManager databaseManager;

    [SerializeField] private GameObject particleAddBomb;
    [SerializeField] private GameObject buttonAddBomb;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        gameManager = FindObjectOfType<GameManager>();
        animCameraEffectBomb = GetComponent<AnimCameraEffectBomb>();
        boomSmoke = GetComponent<BoomSmoke>();
        destroyAllBlocks = GetComponent<DestroyAllBlocks>();
        explosionEffect = GetComponent<ExplosionEffect>();
        bombSound = GetComponent<BombSound>();
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
        databaseManager = FindObjectOfType<DatabaseManager>();
    }

    public void Boom()
    {
        bombSound.PlaySoundBomb();
        UseBomb();
        uILogicsGame.TextGameAmountOfBomb();
        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        sequence.AppendCallback(animCameraEffectBomb.AnimCamera);
        sequence.AppendCallback(boomSmoke.AnimBoomSmokeOn);
        sequence.AppendInterval(2.2f);
        sequence.AppendCallback(destroyAllBlocks.DestroyAllBlocksOnTheScene);
        sequence.AppendInterval(0.2f);
        sequence.AppendCallback(explosionEffect.EffectExplosion);
        sequence.AppendInterval(0.2f);
        sequence.AppendCallback(explosionEffect.EffectExplosionRight);
        sequence.AppendInterval(0.2f);
        sequence.AppendCallback(explosionEffect.EffectExplosionLeft);
        sequence.AppendInterval(2.0f);
        sequence.AppendCallback(boomSmoke.AnimBoomSmokeOff);
        sequence.SetAutoKill(true);
    }

    public void UseBomb()
    {
        gameManager._playerBomb--;
        uILogicTopBar.TextBombTopBarPanel();
        gameManager.SavePlayerPrefsBomb();
        databaseManager.SaveStatsDB();
    }
    public void AddBomb()
    {
        gameManager._playerBomb++;
        Instantiate(particleAddBomb, buttonAddBomb.transform.position, Quaternion.identity);
        gameManager.SavePlayerPrefsBomb();
        databaseManager.SaveStatsDB();
    }
}
