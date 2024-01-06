using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILogicsGame : MonoBehaviour
{
    UILogicTopBar uILogicTopBar;
    UILogicMainMenu uILogicMainMenu;
    GenerationBlocks generationBlocks;
    ClearGamePanel clearGamePanel;
    Health health;
    BestScore bestScore;
    Score score;
    Coins coins;
    MusicSettings musicSettings;
    SoundsSettings soundsSettings;
    Armor armor;
    Bomb bomb;
    PauseAllGameObjects pauseAllGameObjects;
    PlayAllGameObjects playAllGameObjects;

    [SerializeField] private GameObject _GamePanel;
    [SerializeField] private GameObject _PausePanel;
    [SerializeField] private GameObject _LossGamePanel;

    [SerializeField] private TMP_Text _textScoreLossGamePanel;
    [SerializeField] private TMP_Text _textCoinsLossGamePanel;
    [SerializeField] private TMP_Text _textGameAmountOfArmor;
    [SerializeField] private TMP_Text _textGameAmountOfBomb;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicMainMenu = FindObjectOfType<UILogicMainMenu>();
        generationBlocks = FindObjectOfType<GenerationBlocks>();
        clearGamePanel = FindObjectOfType<ClearGamePanel>();
        health = FindObjectOfType<Health>();
        bestScore = FindObjectOfType<BestScore>();
        score = FindObjectOfType<Score>();
        coins = FindObjectOfType<Coins>();
        musicSettings = FindObjectOfType<MusicSettings>();
        soundsSettings = FindObjectOfType<SoundsSettings>();
        armor = FindObjectOfType<Armor>();
        bomb = FindObjectOfType<Bomb>();
        pauseAllGameObjects = FindObjectOfType<PauseAllGameObjects>();
        playAllGameObjects = FindObjectOfType<PlayAllGameObjects>();
    }

    public void LossGamePanel()
    {
        _LossGamePanel.SetActive(true);
        generationBlocks.ScriptEnabledFalse();
        pauseAllGameObjects.PauseAll();
        health.UpdateHealthInGame();
        uILogicTopBar.TopBarPanelIsActiveTrue();
        coins.AddPlayerCoins();
        uILogicTopBar.TextCoinsTopBarPanel();
        bestScore.UpdateBestScore();
        TextScoreLossGamePanel(); 
        TextCoinsLossGamePanel();
        musicSettings.PlayAudioClipsMenu();
    }
    private void TextScoreLossGamePanel()
    {
        _textScoreLossGamePanel.text = score._currentScore.ToString();
    }
    private void TextCoinsLossGamePanel()
    {
        _textCoinsLossGamePanel.text = coins._currentCoinsGame.ToString();
    }

    public void ButtonPause()
    {
        generationBlocks.ScriptEnabledFalse();
        pauseAllGameObjects.PauseAll();
        _PausePanel.SetActive(true);
        uILogicTopBar.TopBarPanelIsActiveTrue();
        musicSettings.PlayAudioClipsMenu();
        soundsSettings.PlaySoundButton();
    }
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
        soundsSettings.PlaySoundButton();
    }
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
        bestScore.UpdateBestScore();
        TextScoreLossGamePanel();
        TextCoinsLossGamePanel();
        soundsSettings.PlaySoundButton();
    }
    public void ButtonContinueGame()
    {
        playAllGameObjects.PlayAll();
        generationBlocks.ScriptEnabledTrue();
        _PausePanel.SetActive(false);
        uILogicTopBar.TopBarPanelIsActiveFalse();
        musicSettings.PlayAudioClipsGame();
        soundsSettings.PlaySoundButton();
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
        _textGameAmountOfArmor.text = armor._playerArmor.ToString();
    }
    public void TextGameAmountOfBomb()
    {
        _textGameAmountOfBomb.text = bomb._playerBomb.ToString();
    }
}
