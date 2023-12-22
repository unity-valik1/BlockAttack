using UnityEngine;
using DG.Tweening;

public class StarAnim : MonoBehaviour
{
    [SerializeField] private Vector3 move = new(-1.068f, -3.969f, 0);
    void Start()
    {
        float randomSpeed = Random.Range(0.3f, 0.9f);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(move, randomSpeed, false)).SetEase(Ease.InCubic);
        sequence.Append(transform.DOScale(1.3f, 0.25f));
        sequence.Append(transform.DOScale(1f, 0.25f));
        sequence.AppendCallback(DeleteObj);    
    }

    void DeleteObj()
    {
        Destroy(gameObject);
    }
}
