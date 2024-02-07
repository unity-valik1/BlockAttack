//using DG.Tweening.Core.Easing;
//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class UILogicRegistrationNamePanel : MonoBehaviour
//{
//    GameManager gameManager;
//    DatabaseManager databaseManager;

//    public GameObject _panelPlayerName;
//    public TMP_InputField _textPlayerName;

//    public int _registered = 0;

//    private void Awake()
//    {
//        Init();
//    }
//    private void Init()
//    {
//        gameManager = FindObjectOfType<GameManager>();
//        databaseManager = FindObjectOfType<DatabaseManager>();
//    }
//    private void Start()
//    {
//        //if (PlayerPrefs.HasKey("_registered"))
//        //{
//        //    _registered = PlayerPrefs.GetInt("_registered");

//        //}
//        //if (_registered == 0)
//        //{
//        //    PanelPlayerNameTrue();
//        //}
//    }
//    public void ButtonSavePlayerName()
//    {
//        gameManager._playerName = _textPlayerName.text;
//        gameManager.SaveAllPlayerPrefs();

//        databaseManager.SaveStatsDB();

//        PanelPlayerNameFalse();
//        _registered = 1;
//        SavePlayerPrefsRegistered();
//    }

//    public void PanelPlayerNameTrue()
//    {
//        _panelPlayerName.SetActive(true);
//    }
//    public void PanelPlayerNameFalse()
//    {
//        _panelPlayerName.SetActive(false);
//    }

//    public void SavePlayerPrefsRegistered()
//    {
//        PlayerPrefs.SetInt("_registered", _registered);
//        PlayerPrefs.Save();
//    }
//}
