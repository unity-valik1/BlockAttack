using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILogicMainMenu : MonoBehaviour
{
    UILogicTopBar uILogicTopBar;
    UILogicsGame uILogicsGame;
    GenerationBlocks generationBlocks;
    Health health;
    Score score;
    Coins coins;
    MusicSettings musicSettings;
    Armor armor;
    Tween tween;

    [SerializeField] private GameObject _MainMenuPanel;
    [SerializeField] private TMP_Text _textNewGame;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
        generationBlocks = FindObjectOfType<GenerationBlocks>();
        health = FindObjectOfType<Health>();
        score = FindObjectOfType<Score>();
        coins = FindObjectOfType<Coins>();
        musicSettings = FindObjectOfType<MusicSettings>();
        armor = FindObjectOfType<Armor>();
    }
    private void Start()
    {
        MainMenuPanelIsActiveTrue();
        AnimTextNewGameTrue();
    }
    public void ButtonNewGame()
    {
        AnimTextNewGameFalse();
        MainMenuPanelIsActiveFalse();
        uILogicsGame.GamePanelIsActiveTrue();
        uILogicsGame.TextGameAmountOfArmor();
        uILogicsGame.TextGameAmountOfBomb();
        generationBlocks.ScriptEnabledTrue();
        uILogicTopBar.TopBarPanelIsActiveFalse();
        health.UpdateAddHealth(3);
        armor.ArmoreOff();
        score.ResetScore();
        coins.ResetCoins();
        musicSettings.PlayAudioClipsGame();
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
}
