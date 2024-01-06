using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteManager : MonoBehaviour
{

    [SerializeField] private Sprite _downButtonCircleSprite;
    [SerializeField] private Sprite _upButtonCircleSprite;

    [SerializeField] private Image _pauseButtonImage;
    [SerializeField] private Image _bombButtonImage;
    [SerializeField] private Image _armorButtonImage;
    [SerializeField] private Image _settingsButtonImage;
    [SerializeField] private Image _shopButtonImage;
    [SerializeField] private Image _musicButtonImage;
    [SerializeField] private Image _soundsButtonImage;

    [SerializeField] private Sprite _downButtonRectangleSprite;
    [SerializeField] private Sprite _upButtonRectangleSprite;

    [SerializeField] private Image _leftButtonImage;
    [SerializeField] private Image _rightButtonImage;
    [SerializeField] private Image _jumpButtonImage;
    [SerializeField] private Image _continueButtonImage;
    [SerializeField] private Image _menuButtonImage;
    [SerializeField] private Image _addArmorButtonImage;
    [SerializeField] private Image _addArmorForCoinsButtonImage;
    [SerializeField] private Image _addCoinsButtonImage;
    [SerializeField] private Image _addBombButtonImage;
    [SerializeField] private Image _addBombForCoinsButtonImage;

    [SerializeField] private Sprite _downButtonSquareSprite;
    [SerializeField] private Sprite _upButtonSquareSprite;

    [SerializeField] private Image _closeSettingsButtonImage;
    [SerializeField] private Image _closeAddArmorButtonImage;
    [SerializeField] private Image _closeAddCoinsButtonImage;
    [SerializeField] private Image _closeAddBombButtonImage;

    //CircleSprite - Круглые кнопки
    public void OnButtonPauseDown()
    {
        _pauseButtonImage.sprite = _downButtonCircleSprite;
    }
    public void OnButtonPauseUp()
    {
        _pauseButtonImage.sprite = _upButtonCircleSprite;
    }

    public void OnButtonBombDown()
    {
        _bombButtonImage.sprite = _downButtonCircleSprite;
    }
    public void OnButtonBombUp()
    {
        _bombButtonImage.sprite = _upButtonCircleSprite;
    }

    public void OnButtonArmorDown()
    {
        _armorButtonImage.sprite = _downButtonCircleSprite;
    }
    public void OnButtonArmorUp()
    {
        _armorButtonImage.sprite = _upButtonCircleSprite;
    }

    public void OnButtonSettingsDown()
    {
        _settingsButtonImage.sprite = _downButtonCircleSprite;
    }
    public void OnButtonSettingsUp()
    {
        _settingsButtonImage.sprite = _upButtonCircleSprite;
    }

    public void OnButtonShopDown()
    {
        _shopButtonImage.sprite = _downButtonCircleSprite;
    }
    public void OnButtonShopUp()
    {
        _shopButtonImage.sprite = _upButtonCircleSprite;
    }

    public void OnButtonMusicDown()
    {
        _musicButtonImage.sprite = _downButtonCircleSprite;
    }
    public void OnButtonMusicUp()
    {
        _musicButtonImage.sprite = _upButtonCircleSprite;
    }

    public void OnButtonSoundsDown()
    {
        _soundsButtonImage.sprite = _downButtonCircleSprite;
    }
    public void OnButtonSoundsUp()
    {
        _soundsButtonImage.sprite = _upButtonCircleSprite;
    }

    //RectangleSprite - Прямоугольные кнопки
    public void OnButtonJumpDown()
    {
        _jumpButtonImage.sprite = _downButtonRectangleSprite;
    }
    public void OnButtonJumpUp()
    {
        _jumpButtonImage.sprite = _upButtonRectangleSprite;
    }

    public void OnButtonMoveLeftDown()
    {
        _leftButtonImage.sprite = _downButtonRectangleSprite;
    }
    public void OnButtonMoveRightDown()
    {
        _rightButtonImage.sprite = _downButtonRectangleSprite;
    }
    public void OnButtonMoveLeftOrRightUp()
    {
        _leftButtonImage.sprite = _upButtonRectangleSprite;
        _rightButtonImage.sprite = _upButtonRectangleSprite;
    }

    public void OnButtonContinueDown()
    {
        _continueButtonImage.sprite = _downButtonRectangleSprite;
    }
    public void OnButtonContinueUp()
    {
        _continueButtonImage.sprite = _upButtonRectangleSprite;
    }

    public void OnButtonMenuDown()
    {
        _menuButtonImage.sprite = _downButtonRectangleSprite;
    }
    public void OnButtonMenuUp()
    {
        _menuButtonImage.sprite = _upButtonRectangleSprite;
    }

    public void OnButtonAddArmorDown()
    {
        _addArmorButtonImage.sprite = _downButtonRectangleSprite;
    }
    public void OnButtonAddArmorUp()
    {
        _addArmorButtonImage.sprite = _upButtonRectangleSprite;
    }
    public void OnButtonAddArmorForCoinsDown()
    {
        _addArmorForCoinsButtonImage.sprite = _downButtonRectangleSprite;
    }
    public void OnButtonAddArmorForCoinsUp()
    {
        _addArmorForCoinsButtonImage.sprite = _upButtonRectangleSprite;
    }
    public void OnButtonAddCoinsDown()
    {
        _addCoinsButtonImage.sprite = _downButtonRectangleSprite;
    }
    public void OnButtonAddCoinsUp()
    {
        _addCoinsButtonImage.sprite = _upButtonRectangleSprite;
    }
    public void OnButtonAddBombDown()
    {
        _addBombButtonImage.sprite = _downButtonRectangleSprite;
    }
    public void OnButtonAddBombUp()
    {
        _addBombButtonImage.sprite = _upButtonRectangleSprite;
    }
    public void OnButtonAddBombForCoinsDown()
    {
        _addBombForCoinsButtonImage.sprite = _downButtonRectangleSprite;
    }
    public void OnButtonAddBombForCoinsUp()
    {
        _addBombForCoinsButtonImage.sprite = _upButtonRectangleSprite;
    }


    //SquareSprite - Квадратные кнопки
    public void OnButtonCloseSettingsDown()
    {
        _closeSettingsButtonImage.sprite = _downButtonSquareSprite;
    }
    public void OnButtonCloseSettingsUp()
    {
        _closeSettingsButtonImage.sprite = _upButtonSquareSprite;
    }
   
    public void OnButtonCloseAddArmorDown()
    {
        _closeAddArmorButtonImage.sprite = _downButtonSquareSprite;
    }
    public void OnButtonCloseAddArmorUp()
    {
        _closeAddArmorButtonImage.sprite = _upButtonSquareSprite;
    }
    public void OnButtonCloseAddCoinsDown()
    {
        _closeAddCoinsButtonImage.sprite = _downButtonSquareSprite;
    }
    public void OnButtonCloseAddCoinsUp()
    {
        _closeAddCoinsButtonImage.sprite = _upButtonSquareSprite;
    }
    public void OnButtonCloseAddBombDown()
    {
        _closeAddBombButtonImage.sprite = _downButtonSquareSprite;
    }
    public void OnButtonCloseAddBombUp()
    {
        _closeAddBombButtonImage.sprite = _upButtonSquareSprite;
    }
}
