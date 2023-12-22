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
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        animCameraEffectBomb = GetComponent<AnimCameraEffectBomb>();
        boomSmoke = GetComponent<BoomSmoke>();
        destroyAllBlocks = GetComponent<DestroyAllBlocks>();
        explosionEffect = GetComponent<ExplosionEffect>();
    }
    public void Boom()
    {
        Sequence sequence = DOTween.Sequence();
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
}
