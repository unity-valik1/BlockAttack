using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsAnim : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] private Vector3 move = new(-1.068f, -3.969f, 0);
    Tween tween;
    void Start()
    {
        RandomOrderLayer();
        float randomSpeed = Random.Range(0.3f, 0.9f);
        Sequence sequence = DOTween.Sequence();
        tween = sequence;
        sequence.Append(transform.DOMove(move, randomSpeed, false)).SetEase(Ease.InCubic);
        sequence.Append(transform.DOScale(1.3f, 0.25f));
        sequence.Append(transform.DOScale(1f, 0.25f));
        sequence.AppendCallback(DeleteObj);
    }

    private void RandomOrderLayer()
    {
        sr = GetComponent<SpriteRenderer>();
        int randomOrderLayer = Random.Range(11, 13);
        sr.sortingOrder = randomOrderLayer;
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
        Destroy(gameObject);
    }
}
