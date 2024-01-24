using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILogicsGame : MonoBehaviour
{
    GameManager gameManager;
    UILogicTopBar uILogicTopBar;
    UILogicMainMenu uILogicMainMenu;
    GenerationBlocks generationBlocks;
    ClearGamePanel clearGamePanel;
    Health health;
    //Health GetActivePlayerHealth()
    //{
    //    return PlayerManager.Instance.ActivePlayer.PlayerHealth;
    //}
    Score score;
    Coins coins;
    MusicSettings musicSettings;
    SoundsSettings soundsSettings;
    PauseAllGameObjects pauseAllGameObjects;
    PlayAllGameObjects playAllGameObjects;
    Armor armor;
    ArmorTimer armorTimer;

    [SerializeField] private GameObject _GamePanel;
    [SerializeField] private GameObject _PausePanel;
    [SerializeField] private GameObject _LossGamePanel;

    [SerializeField] private GameObject[] _lifesItems;

    [SerializeField] private TMP_Text _textScoreLossGamePanel;
    [SerializeField] private TMP_Text _textCoinsLossGamePanel;
    [SerializeField] private TMP_Text _textGameAmountOfArmor;
    [SerializeField] private TMP_Text _textGameAmountOfBomb;
    [SerializeField] private TMP_Text _textGameAmountOfPick;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        gameManager = FindObjectOfType<GameManager>();
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicMainMenu = FindObjectOfType<UILogicMainMenu>();
        generationBlocks = FindObjectOfType<GenerationBlocks>();
        clearGamePanel = FindObjectOfType<ClearGamePanel>();
        health = FindObjectOfType<Health>();
        score = FindObjectOfType<Score>();
        coins = FindObjectOfType<Coins>();
        musicSettings = FindObjectOfType<MusicSettings>();
        soundsSettings = FindObjectOfType<SoundsSettings>();
        pauseAllGameObjects = FindObjectOfType<PauseAllGameObjects>();
        playAllGameObjects = FindObjectOfType<PlayAllGameObjects>();
        armor = FindObjectOfType<Armor>();
        armorTimer = FindObjectOfType<ArmorTimer>();
    }

    //панель проигрыша
    public void LossGamePanel()
    {
        _LossGamePanel.SetActive(true);
        generationBlocks.ScriptEnabledFalse();
        pauseAllGameObjects.PauseAll();
        UpdateHealthInGame();
        uILogicTopBar.TopBarPanelIsActiveTrue();
        coins.AddPlayerCoins();
        uILogicTopBar.TextCoinsTopBarPanel();
        uILogicMainMenu.UpdateBestScore();
        TextScoreLossGamePanel(); 
        TextCoinsLossGamePanel();
        armor.ArmoreOff();
        musicSettings.PlayAudioClipsMenu();
        armorTimer.StopTimer();
    }
    private void TextScoreLossGamePanel()
    {
        _textScoreLossGamePanel.text = score._currentScore.ToString();
    }
    private void TextCoinsLossGamePanel()
    {
        _textCoinsLossGamePanel.text = coins._currentCoinsGame.ToString();
    }


    //кнопка паузы
    public void ButtonPause()
    {
        generationBlocks.ScriptEnabledFalse();
        pauseAllGameObjects.PauseAll();
        _PausePanel.SetActive(true);
        uILogicTopBar.TopBarPanelIsActiveTrue();
        musicSettings.PlayAudioClipsMenu();
        soundsSettings.PlaySoundButton();
        armorTimer.StopTimer();
    }

    //кнопка выйти в меню
    public void ButtonMainMenu()
    {
        _LossGamePanel.SetActive(false);
        _PausePanel.SetActive(false);
        GamePanelIsActiveFalse();
        uILogicMainMenu.MainMenuPanelIsActiveTrue();
        uILogicMainMenu.AnimTextNewGameTrue();
        generationBlocks.ScriptEnabledFalse();
        clearGamePanel.DestroyAll();
        uILogicTopBar.TopBarPanelIsActiveTrue();
        armor.ArmoreOff();
        soundsSettings.PlaySoundButton();
    }

    //кнопка выхода из незаконченной игры
    public void ButtonExitPausePanel()
    {
        _LossGamePanel.SetActive(true);
        uILogicTopBar.TopBarPanelIsActiveTrue();
        GamePanelIsActiveFalse();
        _PausePanel.SetActive(false);
        generationBlocks.ScriptEnabledFalse();
        clearGamePanel.DestroyAll();
        coins.AddPlayerCoins();
        uILogicTopBar.TextCoinsTopBarPanel();
        uILogicMainMenu.UpdateBestScore();
        TextScoreLossGamePanel();
        TextCoinsLossGamePanel();
        soundsSettings.PlaySoundButton();
    }

    //кнопка продолжить игру
    public void ButtonContinueGame()
    {
        playAllGameObjects.PlayAll();
        generationBlocks.ScriptEnabledTrue();
        _PausePanel.SetActive(false);
        uILogicTopBar.TopBarPanelIsActiveFalse();
        musicSettings.PlayAudioClipsGame();
        soundsSettings.PlaySoundButton();
        armorTimer.StartTimer();
    }

    public void GamePanelIsActiveTrue()
    {
        _GamePanel.SetActive(true);
    }
    public void GamePanelIsActiveFalse()
    {
        _GamePanel.SetActive(false);
    }

    public void TextGameAmountOfArmor()
    {
        _textGameAmountOfArmor.text = gameManager._playerArmor.ToString();
    }
    public void TextGameAmountOfBomb()
    {
        _textGameAmountOfBomb.text = gameManager._playerBomb.ToString();
    }
    public void TextGameAmountOfPick()
    {
        _textGameAmountOfPick.text = gameManager._playerPick.ToString();
    }



    public void UpdateHealthInGame()
    {
        for (int i = 0; i < _lifesItems.Length; i++)
        {
            if (i < /*GetActivePlayerHealth()*/health.lifes)
            {
                _lifesItems[i].SetActive(true);
            }
            else
            {
                _lifesItems[i].SetActive(false);
            }
        }
    }
    public void AnimLossHealth(int lifes)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_lifesItems[lifes].transform.DOScale(0, 0.5f));
        sequence.AppendCallback(UpdateHealthInGame);
    }
    public void UpdateAddHealth()
    {
        /*GetActivePlayerHealth()*/health.lifes = /*GetActivePlayerHealth()*/health.maxLifes;
        for (int i = 0; i < _lifesItems.Length; i++)
        {
            if (i < /*GetActivePlayerHealth()*/health.lifes)
            {
                _lifesItems[i].SetActive(true);
            }
            else
            {
                _lifesItems[i].SetActive(false);
            }
            AnimAddHealth(i);
        }
    }
    public void AnimAddHealth(int lifes)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(UpdateHealthInGame);
        sequence.Append(_lifesItems[lifes].transform.DOScale(1, 0.5f));
    }

    public void NewPlayer(Player NewPlayerPrefab)
    {
        var prevPlayer = PlayerManager.Instance.ActivePlayer;
        var newPlayer = Instantiate<Player>(NewPlayerPrefab, prevPlayer.transform.position, prevPlayer.transform.rotation);
        Destroy(prevPlayer.gameObject);
        PlayerManager.Instance.ActivePlayer = newPlayer;
    }
}
