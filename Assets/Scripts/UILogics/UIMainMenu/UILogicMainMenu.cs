using UnityEngine;
using UnityEngine.UI;

public class UILogicMainMenu : MonoBehaviour
{
    UILogicTopBar uILogicTopBar;
    UILogicsGame uILogicsGame;
    GenerationBlocks generationBlocks;

    [SerializeField] private GameObject _canvasMainMenu;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
        generationBlocks = FindObjectOfType<GenerationBlocks>();
    }

    public void ButtonNewGame()
    {
        CanvasMainMenuIsActiveFalse();
        uILogicsGame.CanvasGameIsActiveTrue();
        generationBlocks.ScriptEnabledTrue();
        uILogicTopBar.CanvasTopBarIsActiveFalse();
    }

    public void CanvasMainMenuIsActiveTrue()
    {
        _canvasMainMenu.SetActive(true);
    }
    public void CanvasMainMenuIsActiveFalse()
    {
        _canvasMainMenu.SetActive(false);
    }
}
