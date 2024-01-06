using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockAnimDelete : MonoBehaviour
{
    public GameObject particleEffectPrefab;
    public GameObject particleStar;
    public GameObject particleCoin;
    Tween tween;

    private void Start()
    {
        AnimBlockDelete();
    }
    public void AnimBlockDelete()
    {
        Sequence sequence = DOTween.Sequence();
        tween = sequence;
        sequence.Append(transform.DOScale(0f, 1f));
        sequence.AppendCallback(DeleteObj);
    }
    private void ParticleEffect()
    {
        Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        Instantiate(particleStar, transform.position, Quaternion.identity);
        Instantiate(particleCoin, transform.position, Quaternion.identity);
    }
    public void AnimBlockDeleteFalse()
    {
        tween.Kill();
    }

    public void AnimBlockDeletePause()
    {
        tween.Pause();
    }
    public void AnimBlockDeletePlay()
    {
        tween.Play();
    }
    void DeleteObj()
    {
        ParticleEffect();
        Destroy(gameObject);
    }
}
