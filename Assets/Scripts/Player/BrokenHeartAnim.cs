using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenHeartAnim : MonoBehaviour
{
    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(transform.position.y + 2f, 1f, false)).SetEase(Ease.Linear);
        sequence.AppendCallback(DeleteObj);
    }

    void DeleteObj()
    {
        Destroy(gameObject);
    }
}
