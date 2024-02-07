using UnityEngine;

public class ArmorSound : MonoBehaviour
{
    SoundsSettings soundsSettings;
    AudioSource audioSource;

    [SerializeField] private AudioClip audioClipsArmoreIsActiveTrue;
    [SerializeField] private AudioClip audioClipsArmoreIsActiveFalse;
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        soundsSettings = FindObjectOfType<SoundsSettings>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundArmoreIsActiveFalse()
    {
        if (soundsSettings._isActiveSounds == 1)
        {
            audioSource.clip = audioClipsArmoreIsActiveFalse;
            audioSource.Play();
        }
    }
    public void PlaySoundArmoreIsActiveTrue()
    {
        if (soundsSettings._isActiveSounds == 1)
        {
            audioSource.clip = audioClipsArmoreIsActiveTrue;
            audioSource.Play();
        }
    }
}
