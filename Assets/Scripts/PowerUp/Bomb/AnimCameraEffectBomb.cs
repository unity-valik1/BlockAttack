using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCameraEffectBomb : MonoBehaviour
{
    Camera _camera;
    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }
    public void AnimCamera()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_camera.transform.DORotate(new Vector3(0, 0, 4), 0.05f, RotateMode.Fast));
        sequence.AppendInterval(0.01f);
        sequence.Append(_camera.transform.DORotate(new Vector3(0, 0, -4), 0.1f, RotateMode.Fast));
        sequence.AppendInterval(0.01f);
        sequence.Append(_camera.transform.DORotate(new Vector3(0, 0, 0), 0.05f, RotateMode.Fast));
        sequence.AppendInterval(0.01f);
        sequence.SetLoops(20);
    }
}
