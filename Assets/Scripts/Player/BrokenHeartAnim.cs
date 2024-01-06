using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenHeartAnim : MonoBehaviour
{
    Tween tween;
    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        tween = sequence;
        sequence.Append(transform.DOMoveY(transform.position.y + 2f, 1f, false)).SetEase(Ease.Linear);
        sequence.AppendCallback(DeleteObj);
    }

    public void AnimBrokenHeartFalse()
    {
        tween.Kill();
    }
    public void AnimBrokenHeartPause()
    {
        tween.Pause();
    }
    public void AnimBrokenHeartPlay()
    {
        tween.Play();
    }
    void DeleteObj()
    {
        Destroy(gameObject);
    }
}
