using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddArmorAnim : MonoBehaviour
{
    [SerializeField] private GameObject particleEffectPrefab;
    void Start()
    {
        Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        sequence.Append(transform.DOScale(1, 0.5f));
        sequence.Append(transform.DOMoveY(transform.position.y + 1f, 1f, false)).SetEase(Ease.Linear);
        sequence.AppendCallback(DeleteObj);
    }
    void DeleteObj()
    {
        Destroy(gameObject);
    }
}
