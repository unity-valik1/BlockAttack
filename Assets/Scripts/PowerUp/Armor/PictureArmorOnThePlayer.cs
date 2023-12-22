using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureArmorOnThePlayer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _spriteArmorOn;
    [SerializeField] private Sprite _spriteArmorOff;

    public void PictureArmorIsActive()
    {
        _spriteRenderer.sprite = _spriteArmorOn;
    }

    public void PictureArmorIsNotActive()
    {
        _spriteRenderer.sprite = _spriteArmorOff;
    }
}
