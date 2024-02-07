using UnityEngine;
using DG.Tweening;

public class StarAnim : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] private Vector3 move = new(-1.068f, -3.969f, 0);
    Tween tween;

    public bool _onStartMove = true;
    void Start()
    {
        if(_onStartMove)
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
        else
        {
            RandomOrderLayer();
            float randomSpeed = Random.Range(0.3f, 0.9f);
            Sequence sequence = DOTween.Sequence();
            tween = sequence;
            sequence.AppendInterval(1.8f);
            sequence.Append(transform.DOMove(move, randomSpeed, false)).SetEase(Ease.InCubic);
            sequence.Append(transform.DOScale(1.3f, 0.25f));
            sequence.Append(transform.DOScale(1f, 0.25f));
            sequence.AppendCallback(DeleteObj);
        }
    }
    private void RandomOrderLayer()
    {
        sr = GetComponent<SpriteRenderer>();
        int randomOrderLayer = Random.Range(11, 13);
        sr.sortingOrder = randomOrderLayer;
    }

    public void AnimStarFalse()
    {
        tween.Kill();
    }

    public void AnimStarPause()
    {
        tween.Pause();
    }
    public void AnimStarPlay()
    {
        tween.Play();
    }
    void DeleteObj()
    {
        Destroy(gameObject);
    }
}
