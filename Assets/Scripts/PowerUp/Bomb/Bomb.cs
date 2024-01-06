using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bomb : MonoBehaviour
{
    AnimCameraEffectBomb animCameraEffectBomb;
    BoomSmoke boomSmoke;
    DestroyAllBlocks destroyAllBlocks;
    ExplosionEffect explosionEffect;
    BombSound bombSound;
    UILogicTopBar uILogicTopBar;
    UILogicsGame uILogicsGame;

    [SerializeField] private GameObject particleAddBomb;
    [SerializeField] private GameObject buttonAddBomb;

    public int _playerBomb;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        animCameraEffectBomb = GetComponent<AnimCameraEffectBomb>();
        boomSmoke = GetComponent<BoomSmoke>();
        destroyAllBlocks = GetComponent<DestroyAllBlocks>();
        explosionEffect = GetComponent<ExplosionEffect>();
        bombSound = GetComponent<BombSound>();
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
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
        _playerBomb--;
        uILogicTopBar.TextBombTopBarPanel();
        SaveBomb();
    }
    public void AddBomb()
    {
        _playerBomb++;
        Instantiate(particleAddBomb, buttonAddBomb.transform.position, Quaternion.identity);
        SaveBomb();
    }

    public void SaveBomb()
    {
        PlayerPrefs.SetInt("_playerBomb", _playerBomb);
        PlayerPrefs.Save();
    }
    public void LoadBomb()
    {
        if (PlayerPrefs.HasKey("_playerBomb"))
        {
            _playerBomb = PlayerPrefs.GetInt("_playerBomb");
        }
    }
}
