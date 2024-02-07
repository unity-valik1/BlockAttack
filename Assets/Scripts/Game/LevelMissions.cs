using DG.Tweening;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelMissions : MonoBehaviour
{
    UILogicMainMenu uILogicMainMenu;
    UILogicTopBar uILogicTopBar;
    UILogicsGame uILogicsGame;
    GenerationBlocks generationBlocks;
    Coins coins;
    Score score;
    MusicSettings musicSettings;
    PauseAllGameObjects pauseAllGameObjects;
    ClearGamePanel clearGamePanel;
    Armor armor;
    ArmorTimer armorTimer;
    Gates gates;
    SkinsPlayer skinsPlayer;


    [SerializeField] private GameObject _panelMissions;
    [SerializeField] private GameObject[] _panelMissionsNubers;
    [SerializeField] private Image[] _imgBlockItems;
    [SerializeField] private TMP_Text[] _textBlockItems;
    [SerializeField] private Sprite[] _spriteBlockItems;
    [SerializeField] private Image _imgBlackAnim;

    [SerializeField] private GameObject[] _panelsLevelsButtons;
    [SerializeField] private GameObject _panelsLevelsButtonsCloseImage;
    [SerializeField] private GameObject _ErrorBuySkinMilitaryCloseImage;

    public int[] numberImgBlock;
    public int[] amountBlock;
    public int[] arrayWinLevel;
    public Button[] ButtonsLevel;
    readonly int[][] numberImgBlockManager = new[]
    {
        new int[]{0,1},//1
        new int[]{2,3},//2
        new int[]{0,2},//3
        new int[]{1,3},//4
        new int[]{2,3},//5
        new int[]{0,2},//6
        new int[]{0,1},//7
        new int[]{1,3},//8
        new int[]{0,1,2},//9
        new int[]{1,2,3},//10
        new int[]{2,3,0},//11
        new int[]{3,0,1},//12
        new int[]{1,2,3},//13
        new int[]{2,3,0},//14
        new int[]{0,1,2},//15
        new int[]{3,0,1},//16
        
        new int[]{0,1},//17
        new int[]{2,3},//18
        new int[]{0,2},//19
        new int[]{1,3},//20
        new int[]{2,3},//21
        new int[]{0,2},//22
        new int[]{0,1},//23
        new int[]{1,3},//24
        new int[]{0,1,2},//25
        new int[]{1,2,3},//26
        new int[]{2,3,0},//27
        new int[]{3,0,1},//28
        new int[]{1,2,3},//29
        new int[]{2,3,0},//30
        new int[]{0,1,2},//31
        new int[]{3,0,1},//32
    };
    readonly int[][] amountBlockManager = new[]
    {
        new int[]{15,15},//1
        new int[]{15,15},//2
        new int[]{15,15},//3
        new int[]{15,15},//4
        new int[]{30,30},//5
        new int[]{30,30},//6
        new int[]{30,30},//7
        new int[]{30,30},//8
        new int[]{15,15,15},//9
        new int[]{15,15,15},//10
        new int[]{15,15,15},//11
        new int[]{15,15,15},//12
        new int[]{30,30,30},//13
        new int[]{30,30,30},//14
        new int[]{30,30,30},//15
        new int[]{30,30,30},//16

        
        new int[]{15,15},//17
        new int[]{15,15},//18
        new int[]{15,15},//19
        new int[]{15,15},//20
        new int[]{30,30},//21
        new int[]{30,30},//22
        new int[]{30,30},//23
        new int[]{30,30},//24
        new int[]{15,15,15},//25
        new int[]{15,15,15},//26
        new int[]{15,15,15},//27
        new int[]{15,15,15},//28
        new int[]{30,30,30},//29
        new int[]{30,30,30},//30
        new int[]{30,30,30},//31
        new int[]{30,30,30},//32
    };

    public int currentlevel;
    private void Awake()
    {
        Init();
        InitPlayerPrefs();
    }
    private void Init()
    {
        uILogicMainMenu = FindObjectOfType<UILogicMainMenu>();
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
        generationBlocks = FindObjectOfType<GenerationBlocks>();
        coins = FindObjectOfType<Coins>();
        score = FindObjectOfType<Score>();
        musicSettings = FindObjectOfType<MusicSettings>();
        pauseAllGameObjects = FindObjectOfType<PauseAllGameObjects>();
        clearGamePanel = FindObjectOfType<ClearGamePanel>();
        armor = FindObjectOfType<Armor>();
        armorTimer = FindObjectOfType<ArmorTimer>();
        gates = FindObjectOfType<Gates>();
        skinsPlayer = FindObjectOfType<SkinsPlayer>();
    }
    private void InitPlayerPrefs()
    {
        LoadLevel();
    }
    public void NextLevel()
    {
        if (skinsPlayer.arrayBuySkin[1] == 1 && currentlevel == 16)
        {
            Anim();
            currentlevel++;
            LevelManagerUpdateValues();
            LevelManagerUpdateUI();
            print("включить 17 лвл");
        }
        else if (skinsPlayer.arrayBuySkin[1] == 0 && currentlevel == 16)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.AppendCallback(ErrorBuySkinMilitaryCloseImageIsActiveTrue);
            sequence.AppendInterval(1f);
            sequence.AppendCallback(ErrorBuySkinMilitaryCloseImageIsActiveFalse);
        }
        else
        {
            Anim();
            currentlevel++;
            LevelManagerUpdateValues();
            LevelManagerUpdateUI();
        }
    }
    public void ResetLevel()
    {
        Anim();
        LevelManagerUpdateValues();
        LevelManagerUpdateUI();

    }
    public void NumberLevel(int level)
    {
        Anim();
        currentlevel = level;
        LevelManagerUpdateValues();
        LevelManagerUpdateUI();

    }
    public void Anim()
    {
        _imgBlackAnim.gameObject.SetActive(true);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_imgBlackAnim.DOColor(new(0, 0, 0, 1), 0.5f));
        sequence.AppendCallback(CloseMaimMenu);
        sequence.Append(_imgBlackAnim.DOColor(new(0, 0, 0, 0), 0.5f));
        sequence.AppendCallback(BeforeTheGatesOpen);
        sequence.AppendInterval(2f);
        sequence.AppendCallback(AfterTheGatesOpen);
    }
    public void CloseMaimMenu()
    {
        uILogicMainMenu.AnimTextNewGameFalse();
        uILogicTopBar.TopBarPanelIsActiveFalse();
        uILogicMainMenu.MainMenuPanelIsActiveFalse();
        uILogicMainMenu.LevelsPanelIsActiveFalse();
        uILogicsGame.NextLevelPanelIsActiveFalse();
    }
    public void BeforeTheGatesOpen()
    {
        gates.MovementGateInDifferentSides();
        uILogicsGame.TextGameAmountOfArmor();
        uILogicsGame.TextGameAmountOfBomb();
        uILogicsGame.TextGameAmountOfPick();
        generationBlocks.RestartNumberBlocksSpawn();
        generationBlocks.GameModeLevels();
        PanelMissionsIsActive();
        uILogicsGame.UpdateAddHealth();
        score.ResetScore();
        coins.ResetCoins();
        musicSettings.PlayAudioClipsGame();
    }
    public void AfterTheGatesOpen()
    {
        uILogicsGame.GamePanelIsActiveTrue();
        generationBlocks.ScriptEnabledTrue();
        _imgBlackAnim.gameObject.SetActive(false);
    }

    public void LevelManagerUpdateValues()
    {
        numberImgBlock = new int[numberImgBlockManager[currentlevel - 1].Length];
        amountBlock = new int[amountBlockManager[currentlevel - 1].Length];
        for (int i = 0; i < numberImgBlockManager[currentlevel - 1].Length; i++)
        {
            numberImgBlock[i] = numberImgBlockManager[currentlevel - 1][i];
            amountBlock[i] = amountBlockManager[currentlevel - 1][i];
        }
    }
    public void LevelManagerUpdateUI()
    {
        PanelMissionsIsActive();
        for (int i = 0; i < _imgBlockItems.Length; i++)
        {
            if (i < numberImgBlock.Length || i < amountBlock.Length)
            {
                _panelMissionsNubers[i].SetActive(true);
                _imgBlockItems[i].sprite = _spriteBlockItems[numberImgBlock[i]];
                _textBlockItems[i].text = amountBlock[i].ToString();
            }
            else
            {
                _panelMissionsNubers[i].SetActive(false);
            }
        }
    }
    public void PanelMissionsIsActive()
    {
        if (generationBlocks.gameMode == 0)
        {
            _panelMissions.SetActive(false);
        }
        else if (generationBlocks.gameMode == 1)
        {
            _panelMissions.SetActive(true);
        }
    }

    public void MinusBlock(int _numberBlock)
    {
        for (int i = 0; i < numberImgBlock.Length; i++)
        {
            if (_numberBlock == numberImgBlock[i])
            {
                if (amountBlock[i] > 0)
                {
                    amountBlock[i] -= 1;
                    _textBlockItems[i].text = amountBlock[i].ToString();
                }
                else
                {
                    print(amountBlock.Sum());
                    if (amountBlock.Sum() <= 0)
                    {
                        WinLevel();
                    }
                }
                return;
            }
        }
    }
    public void WinLevel()
    {
        SaveLevel(currentlevel);
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(BeforeClosingTheGate);
        sequence.AppendInterval(2f);
        sequence.AppendCallback(AfterClosingTheGate);
    }
    public void BeforeClosingTheGate()
    {
        gates.MovementGateInCenter();
        uILogicsGame.GamePanelIsActiveFalse();
        pauseAllGameObjects.PauseAll();
        clearGamePanel.DestroyAll();
        generationBlocks.ScriptEnabledFalse();
        uILogicsGame.UpdateHealthInGame();
        coins.AddPlayerCoins();
        uILogicMainMenu.UpdateBestScore();
        musicSettings.PlayAudioClipsMenu();
        armorTimer.StopTimer();
    }
    public void AfterClosingTheGate()
    {
        uILogicsGame.NextLevelPanelIsActiveTrue();
        uILogicsGame.TextScoreLossGamePanel();
        uILogicsGame.TextCoinsLossGamePanel();
        uILogicTopBar.TopBarPanelIsActiveTrue();
        uILogicTopBar.TextCoinsTopBarPanel();
        armor.ArmoreOff();
    }

    public void ActivePanelsLevelsButtons(int index)
    {
        for (int i = 0; i < _panelsLevelsButtons.Length; i++)
        {
            if (i == index)
            {
                if (index == 0)
                {
                    _panelsLevelsButtonsCloseImage.SetActive(false);
                }
                else if (index == 1 && skinsPlayer.arrayBuySkin[index] == 1 && arrayWinLevel.Sum() >= 16)
                {
                    _panelsLevelsButtonsCloseImage.SetActive(false);
                }
                else if (index == 1 && skinsPlayer.arrayBuySkin[index] == 0 || arrayWinLevel.Sum() <= 16)
                {
                    _panelsLevelsButtonsCloseImage.SetActive(true);
                }
                _panelsLevelsButtons[i].SetActive(true);
            }
            else
            {
                _panelsLevelsButtons[i].SetActive(false);
            }
        }
    }

    public void SaveLevel(int index)
    {
        string arrayNumberLevel = "arrayNumberLevel" + (index + 1).ToString();
        PlayerPrefs.SetInt(arrayNumberLevel, 1);
        PlayerPrefs.Save();
        arrayWinLevel[index] = 1;

    }
    public void LoadLevel()
    {
        for (int i = 0; i < arrayWinLevel.Length; i++)
        {
            string arrayNumberLevel = "arrayNumberLevel" + (i + 1).ToString();
            if (PlayerPrefs.HasKey(arrayNumberLevel))
            {
                arrayWinLevel[i] = PlayerPrefs.GetInt(arrayNumberLevel);

            }
            if (arrayWinLevel[i] == 1)
            {
                ButtonsLevel[i].interactable = true;
            }
            else
            {
                return;
            }
        }

    }
    public void UpdateLoadLevel()
    {
        for (int i = 0; i < arrayWinLevel.Length; i++)
        {
            if (arrayWinLevel[i] == 1)
            {
                ButtonsLevel[i].interactable = true;
            }
        }
    }

    public void ErrorBuySkinMilitaryCloseImageIsActiveTrue()
    {
        _ErrorBuySkinMilitaryCloseImage.SetActive(true);
    }
    public void ErrorBuySkinMilitaryCloseImageIsActiveFalse()
    {
        _ErrorBuySkinMilitaryCloseImage.SetActive(false);
    }
}
