using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UILogicTopBar : MonoBehaviour
{
    SoundsSettings soundsSettings;
    Coins coins;
    Armor armor;
    Bomb bomb;
    [SerializeField] private GameObject _TopBarPanel;
    [SerializeField] private GameObject _SettingsPanel;

    [SerializeField] private GameObject _AddCoinsPanel;
    [SerializeField] private TMP_Text _textPlayerCoins;

    [SerializeField] private GameObject _AddArmorPanel;
    [SerializeField] private GameObject _AddArmorTV;
    [SerializeField] private TMP_Text _textPlayerArmor;
    [SerializeField] private TMP_Text _textAmountOfArmor;

    [SerializeField] private GameObject _AddBombPanel;
    [SerializeField] private GameObject _AddBombTV;
    [SerializeField] private TMP_Text _textPlayerBomb;
    [SerializeField] private TMP_Text _textAmountOfBomb;

    Tween tween;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        soundsSettings = FindObjectOfType<SoundsSettings>();
        coins = FindObjectOfType<Coins>();
        armor = FindObjectOfType<Armor>();
        bomb = FindObjectOfType<Bomb>();
    }

    private void Start()
    {
        coins.LoadCoins();
        armor.LoadArmor();
        bomb.LoadBomb();
        TopBarPanelIsActiveTrue();
        TextCoinsTopBarPanel();
        TextArmorTopBarPanel();
        TextBombTopBarPanel();
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
        _textPlayerCoins.text = coins._playerCoins.ToString();
    }
    public void TextArmorTopBarPanel()
    {
        _textPlayerArmor.text = armor._playerArmor.ToString();
    }
    public void TextBombTopBarPanel()
    {
        _textPlayerBomb.text = bomb._playerBomb.ToString();
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
        _textAmountOfArmor.text = "У тебя есть: " + armor._playerArmor.ToString();
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
        _textAmountOfBomb.text = "У тебя есть: " + bomb._playerBomb.ToString();
    }


}
