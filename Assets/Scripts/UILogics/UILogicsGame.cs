using DG.Tweening;
using TMPro;
using UnityEngine;

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
    Gates gates;

    [SerializeField] private GameObject _GamePanel;
    [SerializeField] private GameObject _PausePanel;
    [SerializeField] private GameObject _LossGamePanel;
    [SerializeField] private GameObject _NextLevelPanel;

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
        gates = FindObjectOfType<Gates>();
    }

    //панель проигрыша
    public void LossGamePanel()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(BeforeClosingTheGate);
        sequence.AppendInterval(2f);
        sequence.AppendCallback(AfterClosingTheGate);

        //_LossGamePanel.SetActive(true);
        //generationBlocks.ScriptEnabledFalse();
        //pauseAllGameObjects.PauseAll();
        //UpdateHealthInGame();
        //uILogicTopBar.TopBarPanelIsActiveTrue();
        //coins.AddPlayerCoins();
        //uILogicTopBar.TextCoinsTopBarPanel();
        //uILogicMainMenu.UpdateBestScore();
        //TextScoreLossGamePanel();
        //TextCoinsLossGamePanel();
        //armor.ArmoreOff();
        //musicSettings.PlayAudioClipsMenu();
        //armorTimer.StopTimer();
    }
    public void BeforeClosingTheGate()
    {
        gates.MovementGateInCenter();
        GamePanelIsActiveFalse();
        pauseAllGameObjects.PauseAll();
        clearGamePanel.DestroyAll();
        generationBlocks.ScriptEnabledFalse();
        UpdateHealthInGame();
        coins.AddPlayerCoins();
        uILogicMainMenu.UpdateBestScore();
        musicSettings.PlayAudioClipsMenu();
        armorTimer.StopTimer();
    }
    public void AfterClosingTheGate()
    {
        LossGamePanelIsActiveTrue();
        TextScoreLossGamePanel();
        TextCoinsLossGamePanel();
        uILogicTopBar.TopBarPanelIsActiveTrue();
        uILogicTopBar.TextCoinsTopBarPanel();
        armor.ArmoreOff();
    }
    public void TextScoreLossGamePanel()
    {
        _textScoreLossGamePanel.text = score._currentScore.ToString();
    }
    public void TextCoinsLossGamePanel()
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
        LossGamePanelIsActiveFalse();
        PausePanelIsActiveFalse();
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
        if (generationBlocks.gameMode == 0)
        {
            gates.GateInCenter();
            LossGamePanelIsActiveTrue();
            uILogicTopBar.TopBarPanelIsActiveTrue();
            GamePanelIsActiveFalse();
            PausePanelIsActiveFalse();
            generationBlocks.ScriptEnabledFalse();
            clearGamePanel.DestroyAll();
            coins.AddPlayerCoins();
            uILogicTopBar.TextCoinsTopBarPanel();
            uILogicMainMenu.UpdateBestScore();
            TextScoreLossGamePanel();
            TextCoinsLossGamePanel();
            soundsSettings.PlaySoundButton();
        }
        else if (generationBlocks.gameMode == 1)
        {
            gates.GateInCenter();
            LossGamePanelIsActiveFalse();
            PausePanelIsActiveFalse();
            GamePanelIsActiveFalse();
            uILogicTopBar.TopBarPanelIsActiveTrue();
            generationBlocks.ScriptEnabledFalse();
            clearGamePanel.DestroyAll();
            coins.AddPlayerCoins();
            uILogicTopBar.TextCoinsTopBarPanel();
            uILogicMainMenu.UpdateBestScore();
            uILogicMainMenu.MainMenuPanelIsActiveTrue();
            uILogicMainMenu.AnimTextNewGameTrue();
            uILogicTopBar.TopBarPanelIsActiveTrue();
            armor.ArmoreOff();
            soundsSettings.PlaySoundButton();
        }
    }

    //кнопка выхода из панели следующего уровня
    public void ButtonExitNextLevelPanel()
    {
        LossGamePanelIsActiveFalse();
        PausePanelIsActiveFalse();
        NextLevelPanelIsActiveFalse();
        uILogicTopBar.TopBarPanelIsActiveTrue();
        uILogicMainMenu.MainMenuPanelIsActiveTrue();
        uILogicMainMenu.AnimTextNewGameTrue();
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

    public void NextLevelPanelIsActiveTrue()
    {
        _NextLevelPanel.SetActive(true);
    }
    public void NextLevelPanelIsActiveFalse()
    {
        _NextLevelPanel.SetActive(false);
    }
    public void PausePanelIsActiveTrue()
    {
        _PausePanel.SetActive(true);
    }
    public void PausePanelIsActiveFalse()
    {
        _PausePanel.SetActive(false);
    }
    public void LossGamePanelIsActiveTrue()
    {
        _LossGamePanel.SetActive(true);
    }
    public void LossGamePanelIsActiveFalse()
    {
        _LossGamePanel.SetActive(false);
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
        /*GetActivePlayerHealth()*/
        health.lifes = /*GetActivePlayerHealth()*/health.maxLifes;
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
    }//Синглтон
}
