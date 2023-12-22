using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILogicsGame : MonoBehaviour
{
    UILogicTopBar uILogicTopBar;
    UILogicMainMenu uILogicMainMenu;
    GenerationBlocks generationBlocks;
    DestroyAllBlocks destroyAllBlocks;

    [SerializeField] private GameObject _lossGamePanel;
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _canvasGame;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicMainMenu = FindObjectOfType<UILogicMainMenu>();
        generationBlocks = FindObjectOfType<GenerationBlocks>();
        destroyAllBlocks = FindObjectOfType<DestroyAllBlocks>();
    }

    public void LossGamePanel()
    {
        Time.timeScale = 0f;
        _lossGamePanel.SetActive(true);
    }

    public void ButtonContinueGame()
    {
        Time.timeScale = 1f;
        _lossGamePanel.SetActive(false);
        uILogicTopBar.CanvasTopBarIsActiveFalse();
    }

    public void ButtonMainMenu()
    {
        _lossGamePanel.SetActive(false);
        CanvasGameIsActiveFalse();
        uILogicMainMenu.CanvasMainMenuIsActiveTrue();
        generationBlocks.ScriptEnabledFalse();
        destroyAllBlocks.DestroyAllBlocksOnTheScene();
        uILogicTopBar.CanvasTopBarIsActiveTrue();
        Time.timeScale = 1f;
    }

    public void CanvasGameIsActiveTrue()
    {
        _canvasGame.SetActive(true);
    }
    public void CanvasGameIsActiveFalse()
    {
        _canvasGame.SetActive(false);
    }

    public void ButtonPause()
    {
        Time.timeScale = 0f;
        _lossGamePanel.SetActive(true);
        uILogicTopBar.CanvasTopBarIsActiveTrue();
    }
}
