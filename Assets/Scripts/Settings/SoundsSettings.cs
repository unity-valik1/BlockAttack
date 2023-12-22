using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsSettings : MonoBehaviour
{
    private bool _isActiveSounds = true;

    [SerializeField] private GameObject _blockSounds;

    public void ButtonSounds()
    {
        if (_isActiveSounds == true)
        {
            _isActiveSounds = false;
            _blockSounds.SetActive(true);
        }
        else
        {
            _isActiveSounds = true;
            _blockSounds.SetActive(false);
        }
    }
}
