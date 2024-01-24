using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAnimRight : MonoBehaviour
{
    [SerializeField] private GameObject particleEffectsPick;
    [SerializeField] private AudioClip soundEffectsPick;
    [SerializeField] private AudioClip soundEffectsBlockDestroy;
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
        PlayClipAtPoint(soundEffectsPick, transform.position, 1, 0);
        PlayClipAtPoint(soundEffectsBlockDestroy, transform.position, 1, 0);
        Instantiate(particleEffectsPick, transformEffectsPick.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public static void PlayClipAtPoint(AudioClip clip, Vector3 position, [UnityEngine.Internal.DefaultValue("1.0F")] float volume, float spatialBlend)
    {
        GameObject gameObject = new GameObject("One shot audio");
        gameObject.transform.position = position;
        AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
        audioSource.clip = clip;
        audioSource.spatialBlend = spatialBlend;
        audioSource.volume = volume;
        audioSource.Play();
        Object.Destroy(gameObject, clip.length * ((Time.timeScale < 0.01f) ? 0.01f : Time.timeScale));
    }
}
