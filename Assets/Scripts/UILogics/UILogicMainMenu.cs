using DG.Tweening;
using TMPro;
using UnityEngine;

public class UILogicMainMenu : MonoBehaviour
{
    UILogicTopBar uILogicTopBar;
    UILogicsGame uILogicsGame;
    GenerationBlocks generationBlocks;
    Score score;
    Coins coins;
    MusicSettings musicSettings;
    Tween tween;
    //InternetAccess internetAccess;
    SoundsSettings soundsSettings;
    GameManager gameManager;
    //DatabaseManager databaseManager;
    SkinsPlayer skinsPlayer;
    Gates gates;
    LevelMissions levelMissions;

    [SerializeField] private GameObject _MainMenuPanel;
    [SerializeField] private GameObject _scoreboardPanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _scoreboardLoading;
    [SerializeField] private GameObject _LevelsPanel;

    [SerializeField] private TMP_Text _textMyBestScoreOnScoreboardPanel;
    [SerializeField] private TMP_Text _textMyNameOnScoreboardPanel;

    [SerializeField] private TMP_Text _textNewGame;
    public TMP_Text _textBestScore;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
        generationBlocks = FindObjectOfType<GenerationBlocks>();
        score = FindObjectOfType<Score>();
        coins = FindObjectOfType<Coins>();
        musicSettings = FindObjectOfType<MusicSettings>();
        //internetAccess = FindObjectOfType<InternetAccess>();
        soundsSettings = FindObjectOfType<SoundsSettings>();
        gameManager = FindObjectOfType<GameManager>();
        //databaseManager = FindObjectOfType<DatabaseManager>();
        skinsPlayer = FindObjectOfType<SkinsPlayer>();
        gates = FindObjectOfType<Gates>();
        levelMissions = FindObjectOfType<LevelMissions>();
    }

    private void Start()
    {
        MainMenuPanelIsActiveTrue();
        AnimTextNewGameTrue();
        TextBestScoreMainMenu();
    }

    public void ButtonNewGame()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(BeforeTheGatesOpen);
        sequence.AppendInterval(2f);
        sequence.AppendCallback(AfterTheGatesOpen);
    }
    public void BeforeTheGatesOpen()
    {
        gates.MovementGateInDifferentSides();
        AnimTextNewGameFalse();
        uILogicTopBar.TopBarPanelIsActiveFalse();
        MainMenuPanelIsActiveFalse();
        uILogicsGame.TextGameAmountOfArmor();
        uILogicsGame.TextGameAmountOfBomb();
        uILogicsGame.TextGameAmountOfPick();
        generationBlocks.RestartNumberBlocksSpawn();
        generationBlocks.GameModeStandart();
        levelMissions.PanelMissionsIsActive();
        uILogicsGame.UpdateAddHealth();
        score.ResetScore();
        coins.ResetCoins();
        musicSettings.PlayAudioClipsGame();
    }
    public void AfterTheGatesOpen()
    {
        uILogicsGame.GamePanelIsActiveTrue();
        generationBlocks.ScriptEnabledTrue();
    }

    public void TextBestScoreMainMenu()
    {
        _textBestScore.text = gameManager._playerBestScore.ToString();
    }
    public void UpdateBestScore()
    {
        if (gameManager._playerBestScore < score._currentScore)
        {
            gameManager._playerBestScore = score._currentScore;
            _textBestScore.text = gameManager._playerBestScore.ToString();
            gameManager.SavePlayerPrefsBestScore();
            //databaseManager.SaveStatsDB();
        }
    }

    //public void ButtonScoreboardPanel()
    //{
    //    internetAccess.CheckInternetConnectionScoreboard();
    //    MyBestScoreOnScoreboardPanel();
    //}
    public void MyBestScoreOnScoreboardPanel()
    {
        _textMyNameOnScoreboardPanel.text = gameManager._playerName;
        _textMyBestScoreOnScoreboardPanel.text = gameManager._playerBestScore.ToString();
    }
    public void ScoreboardLoadingIsActiveTrue()
    {
        _scoreboardLoading.SetActive(true);
    }
    public void ScoreboardLoadingIsActiveFalse()
    {
        _scoreboardLoading.SetActive(false);
    }
    public void ScoreboardPanelIsActiveTrue()
    {
        _scoreboardPanel.SetActive(true);
    }
    public void ScoreboardPanelIsActiveFalse()
    {
        _scoreboardPanel.SetActive(false);
    }

    public void ButtonShop()
    {
        soundsSettings.PlaySoundButton();
        ShopPanelIsActiveTrue();
        skinsPlayer.ButtonSkin(skinsPlayer.activeSkin);
    }
    public void ShopPanelIsActiveTrue()
    {
        _shopPanel.SetActive(true);
    }

    public void ButtonShopClose()
    {
        soundsSettings.PlaySoundButton();
        ShopPanelIsActiveFalse();
    }
    public void ShopPanelIsActiveFalse()
    {
        _shopPanel.SetActive(false);
    }

    public void MainMenuPanelIsActiveTrue()
    {
        _MainMenuPanel.SetActive(true);
    }
    public void MainMenuPanelIsActiveFalse()
    {
        _MainMenuPanel.SetActive(false);
    }

    public void AnimTextNewGameTrue()
    {
        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        tween = sequence;
        sequence.AppendInterval(1);
        sequence.Append(_textNewGame.transform.DOScale(1.3f, 0.4f));
        sequence.Append(_textNewGame.transform.DOScale(1.0f, 0.4f));
        sequence.Append(_textNewGame.transform.DOScale(1.3f, 0.4f));
        sequence.Append(_textNewGame.transform.DOScale(1.0f, 0.4f));
        sequence.AppendInterval(2);
        sequence.SetLoops(-1);
    }
    public void AnimTextNewGameFalse()
    {
        tween.Kill();
        _textNewGame.transform.localScale = new Vector3(1, 1, 1);
    }
    public void LevelsPanelIsActiveTrue()
    {
        _LevelsPanel.SetActive(true);
        levelMissions.UpdateLoadLevel();
        levelMissions.ActivePanelsLevelsButtons(0);
    }
    public void LevelsPanelIsActiveFalse()
    {
        _LevelsPanel.SetActive(false);
    }
}
