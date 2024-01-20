using UnityEngine;

public class Armor : MonoBehaviour
{
    GameManager gameManager;
    ArmorSound armorSound;
    UILogicTopBar uILogicTopBar;
    UILogicsGame uILogicsGame;
    DatabaseManager databaseManager;
    ArmorTimer armorTimer;

    [SerializeField] private GameObject particleAddArmor;
    [SerializeField] private GameObject buttonAddArmor;
    public GameObject imgPlayerArmor;

    public bool _isArmor = false;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        gameManager = FindObjectOfType<GameManager>();
        armorSound = FindObjectOfType<ArmorSound>();
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
        databaseManager = FindObjectOfType<DatabaseManager>();
        armorTimer = FindObjectOfType<ArmorTimer>();
    }

    public void ArmorIsActive()
    {
        if (_isArmor == false && gameManager._playerArmor >= 1)
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
        gameManager._playerArmor--;
        uILogicTopBar.TextArmorTopBarPanel();
        gameManager.SavePlayerPrefsArmor();
        databaseManager.SaveStatsDB();
    }
    public void AddArmor()
    {
        gameManager._playerArmor++;
        Instantiate(particleAddArmor, buttonAddArmor.transform.position, Quaternion.identity);
        gameManager.SavePlayerPrefsArmor();
        databaseManager.SaveStatsDB();
    }

    public void ArmoreOn()
    {
        _isArmor = true;
        imgPlayerArmor.SetActive(true);
        armorTimer.OnTimerScript();
    }
    public void ArmoreOff()
    {
        _isArmor = false;
        imgPlayerArmor.SetActive(false);
        armorTimer.OffTimerScript();
    }
}
