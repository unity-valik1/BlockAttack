using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Coins : MonoBehaviour
{
    GameManager gameManager;
    UILogicTopBar uILogicTopBar;
    SoundsSettings soundsSettings;
    Armor armor;
    Bomb bomb;
    Pick pick;
    UILogicsGame uILogicsGame;
    DatabaseManager databaseManager;

    [SerializeField] private TMP_Text _textCurrentCoins;
    [SerializeField] private GameObject _coins;

    public int _currentCoinsGame;
    [SerializeField] private int _armorPurchaseCost;
    [SerializeField] private int _bombPurchaseCost;
    [SerializeField] private int _pickPurchaseCost;

    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        gameManager = FindObjectOfType<GameManager>();
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        soundsSettings = FindObjectOfType<SoundsSettings>();
        armor = FindObjectOfType<Armor>();
        bomb = FindObjectOfType<Bomb>();
        pick = FindObjectOfType<Pick>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
        databaseManager = FindObjectOfType<DatabaseManager>();
    }

    public void ResetCoins()
    {
        _currentCoinsGame = 0;
        _textCurrentCoins.text = _currentCoinsGame.ToString();
    }
    public void AddCoinsGame(int amountCoins)
    {
        //int amountCoins = Random.Range(1, 11);
        _currentCoinsGame += amountCoins;
        AnimCoins();
        SetProgress(_currentCoinsGame - amountCoins, _currentCoinsGame, amountCoins);
    }
    public void SetProgress(float value, float maxValue, int amountPoints)
    {
        float normalizedValue = value / maxValue;
        float duration = Mathf.Lerp(_minTime, _maxTime, normalizedValue);

        StartCoroutine(LerpValueCoins(_currentCoinsGame - amountPoints, _currentCoinsGame, duration, SetTextValue));
    }
    private IEnumerator LerpValueCoins(float startValue, float endValue, float duration, UnityAction<float> action)
    {
        //yield return new WaitForSeconds(1.3f);
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            action?.Invoke(nextValue);
            elapsed += Time.deltaTime;
            yield return null;
        }
        _textCurrentCoins.text = _currentCoinsGame.ToString();
    }
    private void SetTextValue(float value)
    {
        value = (int)value;
        _textCurrentCoins.text = value.ToString();
    }

    private void AnimCoins()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(1.3f);
        sequence.Append(_coins.transform.DOScale(1.5f, 0.25f));
        sequence.Append(_coins.transform.DOScale(1f, 0.25f));
    }

    public void UseCoinsForArmor()
    {
        gameManager._playerCoins -= _armorPurchaseCost;
        gameManager.SavePlayerPrefsCoins();
    }
    public void UseCoinsForBomb()
    {
        gameManager._playerCoins -= _bombPurchaseCost;
        gameManager.SavePlayerPrefsCoins();
    }
    public void UseCoinsForPick()
    {
        gameManager._playerCoins -= _pickPurchaseCost;
        gameManager.SavePlayerPrefsCoins();
    }

    public void AddPlayerCoins()
    {
        gameManager._playerCoins += _currentCoinsGame;
        gameManager.SavePlayerPrefsCoins();
        databaseManager.SaveStatsDB();
    }
    public void AddArmorForCoins()
    {
        if (gameManager._playerCoins >= _armorPurchaseCost)
        {
            soundsSettings.PlaySoundButton();
            UseCoinsForArmor();
            armor.AddArmor();
            uILogicTopBar.TextArmorTopBarPanel();
            uILogicTopBar.TextAmountOfArmorAddArmorPanel();
            uILogicTopBar.TextCoinsTopBarPanel();
            uILogicsGame.TextGameAmountOfArmor();
            databaseManager.SaveStatsDB();
        }
        else
        {
            uILogicTopBar.ButtonAddCoins();
        }
    }
    public void AddBombForCoins()
    {
        if (gameManager._playerCoins >= _bombPurchaseCost)
        {
            soundsSettings.PlaySoundButton();
            UseCoinsForBomb();
            bomb.AddBomb();
            uILogicTopBar.TextBombTopBarPanel();
            uILogicTopBar.TextAmountOfBombAddBombPanel();
            uILogicTopBar.TextCoinsTopBarPanel();
            uILogicsGame.TextGameAmountOfBomb();
            databaseManager.SaveStatsDB();
        }
        else
        {
            uILogicTopBar.ButtonAddCoins();
        }
    }
    public void AddPickForCoins()
    {
        if (gameManager._playerCoins >= _pickPurchaseCost)
        {
            soundsSettings.PlaySoundButton();
            UseCoinsForPick();
            pick.AddPick();
            uILogicTopBar.TextPickTopBarPanel();
            uILogicTopBar.TextAmountOfPickAddPickPanel();
            uILogicTopBar.TextCoinsTopBarPanel();
            uILogicsGame.TextGameAmountOfPick();
            databaseManager.SaveStatsDB();
        }
        else
        {
            uILogicTopBar.ButtonAddCoins();
        }
    }
}
