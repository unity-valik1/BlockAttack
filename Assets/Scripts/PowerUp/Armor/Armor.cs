using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Armor : MonoBehaviour
{
    ArmorSound armorSound;
    UILogicTopBar uILogicTopBar;
    UILogicsGame uILogicsGame;

    [SerializeField] private GameObject particleAddArmor;
    [SerializeField] private GameObject buttonAddArmor;
    [SerializeField] public GameObject imgPlayerArmor;


    public bool _isArmor = false;
    public int _playerArmor;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        armorSound = FindObjectOfType<ArmorSound>();
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
    }
    public void ArmorIsActive()
    {
        if (_isArmor == false && _playerArmor >= 1)
        {
            armorSound.PlaySoundArmoreIsActiveTrue();
            ArmoreOn();
            UseArmor();
            uILogicsGame.TextGameAmountOfArmor();
            imgPlayerArmor.SetActive(true);
        }
        else
        {
            //todo броня активна
        }
    }

    public void UseArmor()
    {
        _playerArmor--;
        uILogicTopBar.TextArmorTopBarPanel();
        SaveArmor();
    }
    public void AddArmor()
    {
        _playerArmor++;
        Instantiate(particleAddArmor, buttonAddArmor.transform.position, Quaternion.identity);
        SaveArmor();
    }

    public void ArmoreOn()
    {
        _isArmor = true;
    }
    public void ArmoreOff()
    {
        _isArmor = false;
    }

    public void SaveArmor()
    {
        PlayerPrefs.SetInt("_playerArmor", _playerArmor);
        PlayerPrefs.Save();
    }
    public void LoadArmor()
    {
        if (PlayerPrefs.HasKey("_playerArmor"))
        {
            _playerArmor = PlayerPrefs.GetInt("_playerArmor");
        }
    }
}
