using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardElement : MonoBehaviour
{
    public TMP_Text _userNumberPlaceText;
    public TMP_Text _userNameText;
    public TMP_Text _userBestScoreText;
    public Image _imgPlace; 
    public Sprite[] _imgsPlace; 

    public void NewScoreElement (string _userName, int _userBestScore, int _userNumberPlace)
    {
        _userNameText.text= _userName;
        _userBestScoreText.text = _userBestScore.ToString();
        _userNumberPlaceText.text = _userNumberPlace.ToString();
    }
    public void UpdateImgPlace (int numberPlace) 
    {
        _imgPlace.gameObject.SetActive(true);
        _imgPlace.sprite= _imgsPlace[numberPlace-1];
    }
}
