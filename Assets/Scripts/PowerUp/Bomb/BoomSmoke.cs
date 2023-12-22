using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomSmoke : MonoBehaviour
{
    [SerializeField] private Animation _animation;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _animationGO;

    public void AnimBoomSmokeOn()
    {
        _animationGO.gameObject.SetActive(true);
        _canvas.sortingOrder = 50;
        _animation.Play();
    }

    public void AnimBoomSmokeOff()
    {
        _animationGO.gameObject.SetActive(false);
        _canvas.sortingOrder = 10;
    }
}
