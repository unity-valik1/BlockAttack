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

    public bool animDeleteView = true;

    private void Start()
    {
        if(animDeleteView)
        {
            AnimBlockDelete();
        }
        else
        {
            AnimBlockDeleteBomb();
        }
    }
    public void AnimBlockDelete()
    {
        Sequence sequence = DOTween.Sequence();
        tween = sequence;
        sequence.Append(transform.DOScale(0f, 0.5f));
        sequence.AppendCallback(DeleteObj);
    }
    public void AnimBlockDeleteBomb()
    {
        Sequence sequence = DOTween.Sequence();
        tween = sequence;
        sequence.Append(transform.DOScale(0f, 0.5f));
        sequence.AppendCallback(DeleteObjBomb);
    }
    void DeleteObj()
    {
        ParticleEffect();
        Destroy(gameObject);
    }
    void DeleteObjBomb()
    {
        ParticleEffectBomb();
        Destroy(gameObject);
    }
    private void ParticleEffect()
    {
        Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        Instantiate(particleStar, transform.position, Quaternion.identity);
        Instantiate(particleCoin, transform.position, Quaternion.identity);
    }
    private void ParticleEffectBomb()
    {
        Instantiate(particleStar, transform.position, Quaternion.identity).GetComponent<StarAnim>()._onStartMove = false;
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
}
