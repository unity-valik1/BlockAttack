using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSettings : MonoBehaviour
{
    private bool _isActiveMusic = true;

    [SerializeField] private GameObject _blockMusic;

    public void ButtonMusic()
    {
        if(_isActiveMusic == true)
        {
            _isActiveMusic = false;
            _blockMusic.SetActive(true);
        }
        else
        {
            _isActiveMusic = true;
            _blockMusic.SetActive(false);
        }
    }
}
