using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAnimRight : MonoBehaviour
{
    [SerializeField] private GameObject particleEffectsPick;
    [SerializeField] private GameObject transformEffectsPick;
    Tween tween;
    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        tween = sequence;
        sequence.Append(transform.DORotate(new Vector3(0, 0, -40), 0.15f, RotateMode.Fast));
        sequence.Append(transform.DORotate(new Vector3(0, 0, +100), 0.35f, RotateMode.Fast));
        sequence.AppendCallback(DeleteObj);
    }
    public void AnimCoinFalse()
    {
        tween.Kill();
    }

    public void AnimCoinPause()
    {
        tween.Pause();
    }
    public void AnimCoinPlay()
    {
        tween.Play();
    }
    void DeleteObj()
    {
        Instantiate(particleEffectsPick, transformEffectsPick.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
