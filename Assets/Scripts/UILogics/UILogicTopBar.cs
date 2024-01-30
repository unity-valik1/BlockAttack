using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using DG.Tweening.Core.Easing;
using UnityEngine.UI;

public class UILogicTopBar : MonoBehaviour
{
    GameManager gameManager;
    SoundsSettings soundsSettings;
    Coins coins;


    [SerializeField] private GameObject _TopBarPanel;
    [SerializeField] private GameObject _SettingsPanel;

    [SerializeField] private GameObject _AddCoinsPanel;
    public TMP_Text _textPlayerCoins;

    [SerializeField] private GameObject _AddArmorPanel;
    [SerializeField] private GameObject _AddArmorTV;
    public TMP_Text _textPlayerArmor;
    [SerializeField] private TMP_Text _textAmountOfArmor;

    [SerializeField] private GameObject _AddBombPanel;
    [SerializeField] private GameObject _AddBombTV;
    public TMP_Text _textPlayerBomb;
    [SerializeField] private TMP_Text _textAmountOfBomb;

    [SerializeField] private GameObject _AddPickPanel;
    [SerializeField] private GameObject _AddPickTV;
    public TMP_Text _textPlayerPick;
    [SerializeField] private TMP_Text _textAmountOfPick;
    [SerializeField] HorizontalLayoutGroup _horizontalLayoutGroup;
    Tween tween;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        gameManager = FindObjectOfType<GameManager>();
        soundsSettings = FindObjectOfType<SoundsSettings>();
        coins = FindObjectOfType<Coins>();
    }

    private void Start()
    {
        TopBarPanelIsActiveTrue();
        TextCoinsTopBarPanel();
        TextArmorTopBarPanel();
        TextBombTopBarPanel();
        TextPickTopBarPanel();
        Canvas.ForceUpdateCanvases();
        _horizontalLayoutGroup.enabled = false;
        _horizontalLayoutGroup.enabled = true;
    }

    //ТопБар
    public void TopBarPanelIsActiveTrue()
    {
        _TopBarPanel.SetActive(true);

    }
    public void TopBarPanelIsActiveFalse()
    {
        _SettingsPanel.transform.DOScale(0, 0.5f);
        _TopBarPanel.SetActive(false);
    }

    public void TextCoinsTopBarPanel()
    {
        _textPlayerCoins.text = gameManager._playerCoins.ToString();
    }
    public void TextArmorTopBarPanel()
    {
        _textPlayerArmor.text = gameManager._playerArmor.ToString();
    }
    public void TextBombTopBarPanel()
    {
        _textPlayerBomb.text = gameManager._playerBomb.ToString();
    }
    public void TextPickTopBarPanel()
    {
        _textPlayerPick.text = gameManager._playerPick.ToString();
    }

    //Настройки
    public void ButtonSettings()
    {
        soundsSettings.PlaySoundButton();
        SettingsPanelIsActiveTrue();
        AnimSettingsPanel();
    }
    private void SettingsPanelIsActiveTrue()
    {
        _SettingsPanel.SetActive(true);
    }
    private void AnimSettingsPanel()
    {
        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        sequence.Append(_SettingsPanel.transform.DOScale(1.1f, 0.1f));
        sequence.Append(_SettingsPanel.transform.DOScale(1f, 0.1f));
    }

    public void ButtonSettingsClose()
    {
        soundsSettings.PlaySoundButton();
        SettingsPanelIsActiveFalse();
    }
    private void SettingsPanelIsActiveFalse()
    {
        _SettingsPanel.SetActive(false);
    }

    //Монеты
    public void ButtonAddCoins()
    {
        soundsSettings.PlaySoundButton();
        AddCoinsPanelIsActiveTrue();
        AnimAddCoinsPanel();
    }
    public void AddCoinsPanelIsActiveTrue()
    {
        _AddCoinsPanel.SetActive(true);
    }
    private void AnimAddCoinsPanel()
    {
        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        sequence.Append(_AddCoinsPanel.transform.DOScale(1.1f, 0.1f));
        sequence.Append(_AddCoinsPanel.transform.DOScale(1f, 0.1f));
    }

    public void ButtonAddCoinsClose()
    {
        soundsSettings.PlaySoundButton();
        AddCoinsPanelIsActiveFalse();
    }
    public void AddCoinsPanelIsActiveFalse()
    {
        _AddCoinsPanel.SetActive(false);
    }

    //Броня
    public void ButtonAddArmor()
    {
        soundsSettings.PlaySoundButton();
        TextAmountOfArmorAddArmorPanel();
        AddArmorPanelIsActiveTrue();
        AnimAddArmorPanel();
        AnimAddArmorPanelTVTrue();
    }
    private void AddArmorPanelIsActiveTrue()
    {
        _AddArmorPanel.SetActive(true);
    }
    private void AnimAddArmorPanel()
    {
        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        sequence.Append(_AddArmorPanel.transform.DOScale(1.1f, 0.1f));
        sequence.Append(_AddArmorPanel.transform.DOScale(1f, 0.1f));
    }
    private void AnimAddArmorPanelTVTrue()
    {
        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        tween = sequence;
        sequence.AppendInterval(1);
        sequence.Append(_AddArmorTV.transform.DORotate(new Vector3(0, 0, 10), 0.1f, RotateMode.Fast));
        sequence.Append(_AddArmorTV.transform.DORotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast));
        sequence.Append(_AddArmorTV.transform.DORotate(new Vector3(0, 0, -10), 0.1f, RotateMode.Fast));
        sequence.Append(_AddArmorTV.transform.DORotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast));
        sequence.Append(_AddArmorTV.transform.DORotate(new Vector3(0, 0, 10), 0.1f, RotateMode.Fast));
        sequence.Append(_AddArmorTV.transform.DORotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast));
        sequence.AppendInterval(2);
        sequence.SetLoops(-1);
    }

    public void ButtonAddArmorClose()
    {
        soundsSettings.PlaySoundButton();
        AddArmorPanelIsActiveFalse();
        AnimAddArmorPanelTVFalse();
    }
    private void AddArmorPanelIsActiveFalse()
    {
        _AddArmorPanel.SetActive(false);
    }
    private void AnimAddArmorPanelTVFalse()
    {
        tween.Kill();
        _AddArmorTV.transform.rotation = Quaternion.identity;
    }

    public void ButtonAddArmorForCoins()
    {
        coins.AddArmorForCoins();
    }
    public void TextAmountOfArmorAddArmorPanel()
    {
        _textAmountOfArmor.text = "У тебя есть: " + gameManager._playerArmor.ToString();
    }

    //Бомба
    public void ButtonAddBomb()
    {
        soundsSettings.PlaySoundButton();
        TextAmountOfBombAddBombPanel();
        AddBombPanelIsActiveTrue();
        AnimAddBombPanel();
        AnimAddBombPanelTVTrue();
    }
    private void AddBombPanelIsActiveTrue()
    {
        _AddBombPanel.SetActive(true);
    }
    private void AnimAddBombPanel()
    {
        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        sequence.Append(_AddBombPanel.transform.DOScale(1.1f, 0.1f));
        sequence.Append(_AddBombPanel.transform.DOScale(1f, 0.1f));
    }
    private void AnimAddBombPanelTVTrue()
    {
        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        tween = sequence;
        sequence.AppendInterval(1);
        sequence.Append(_AddBombTV.transform.DORotate(new Vector3(0, 0, 10), 0.1f, RotateMode.Fast));
        sequence.Append(_AddBombTV.transform.DORotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast));
        sequence.Append(_AddBombTV.transform.DORotate(new Vector3(0, 0, -10), 0.1f, RotateMode.Fast));
        sequence.Append(_AddBombTV.transform.DORotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast));
        sequence.Append(_AddBombTV.transform.DORotate(new Vector3(0, 0, 10), 0.1f, RotateMode.Fast));
        sequence.Append(_AddBombTV.transform.DORotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast));
        sequence.AppendInterval(2);
        sequence.SetLoops(-1);
    }

    public void ButtonAddBombClose()
    {
        soundsSettings.PlaySoundButton();
        AddBombPanelIsActiveFalse();
        AnimAddBombPanelTVFalse();
    }
    private void AddBombPanelIsActiveFalse()
    {
        _AddBombPanel.SetActive(false);
    }
    private void AnimAddBombPanelTVFalse()
    {
        tween.Kill();
        _AddBombTV.transform.rotation = Quaternion.identity;
    }

    public void ButtonAddBombForCoins()
    {
        coins.AddBombForCoins();
    }
    public void TextAmountOfBombAddBombPanel()
    {
        _textAmountOfBomb.text = "У тебя есть: " + gameManager._playerBomb.ToString();
    }

    //Кирка
    public void ButtonAddPick()
    {
        soundsSettings.PlaySoundButton();
        TextAmountOfPickAddPickPanel();
        AddPickPanelIsActiveTrue();
        AnimAddPickPanel();
        AnimAddPickPanelTVTrue();
    }
    private void AddPickPanelIsActiveTrue()
    {
        _AddPickPanel.SetActive(true);
    }
    private void AnimAddPickPanel()
    {
        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        sequence.Append(_AddPickPanel.transform.DOScale(1.1f, 0.1f));
        sequence.Append(_AddPickPanel.transform.DOScale(1f, 0.1f));
    }
    private void AnimAddPickPanelTVTrue()
    {
        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        tween = sequence;
        sequence.AppendInterval(1);
        sequence.Append(_AddPickTV.transform.DORotate(new Vector3(0, 0, 10), 0.1f, RotateMode.Fast));
        sequence.Append(_AddPickTV.transform.DORotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast));
        sequence.Append(_AddPickTV.transform.DORotate(new Vector3(0, 0, -10), 0.1f, RotateMode.Fast));
        sequence.Append(_AddPickTV.transform.DORotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast));
        sequence.Append(_AddPickTV.transform.DORotate(new Vector3(0, 0, 10), 0.1f, RotateMode.Fast));
        sequence.Append(_AddPickTV.transform.DORotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast));
        sequence.AppendInterval(2);
        sequence.SetLoops(-1);
    }

    public void ButtonAddPickClose()
    {
        soundsSettings.PlaySoundButton();
        AddPickPanelIsActiveFalse();
        AnimAddPickPanelTVFalse();
    }
    private void AddPickPanelIsActiveFalse()
    {
        _AddPickPanel.SetActive(false);
    }
    private void AnimAddPickPanelTVFalse()
    {
        tween.Kill();
        _AddPickTV.transform.rotation = Quaternion.identity;
    }

    public void ButtonAddPickForCoins()
    {
        coins.AddPickForCoins();
    }
    public void TextAmountOfPickAddPickPanel()
    {
        _textAmountOfPick.text = "У тебя есть: " + gameManager._playerPick.ToString();
    }
}
