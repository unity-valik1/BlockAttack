using UnityEngine;
using UnityEngine.UI;

public class SkinsPlayer : MonoBehaviour
{
    ViewCupOnPlayer viewCupOnPlayer;
    GameManager gameManager;
    UILogicTopBar uILogicTopBar;
    SoundsSettings soundsSettings;
    DatabaseManager databaseManager;


    [SerializeField] private Animator animatorPlayer;

    [SerializeField] private Animator animatorSkinShop;
    [SerializeField] private RuntimeAnimatorController[] animatorControllerSkin;

    //активный скин
    public int activeSkin = 0;

    public int[] arrayPriceOfSkins = new int[2];
    //куплен скин -1 не куплен -0
    [SerializeField] private int[] arrayBuySkin = new int[2];

    [SerializeField] private GameObject[] buySkinButton;
    [SerializeField] private GameObject[] buySkinText;
    [SerializeField] private GameObject[] buySkinPutButton;

    //фон кнопки нажата или нет
    [SerializeField] private Image[] imgButtons;
    [SerializeField] private Sprite spriteButtonOn;
    [SerializeField] private Sprite spriteButtonOff;

    //скины и шапки
    [SerializeField] private RuntimeAnimatorController[] animatorControllersPlayer;
    [SerializeField] private Sprite[] cupsForward;
    [SerializeField] private Sprite[] cupsLeft;
    [SerializeField] private Sprite[] cupsRight;
    private void Awake()
    {
        Init();
        InitPlayerPrefs();
    }
    private void Init()
    {
        viewCupOnPlayer = FindObjectOfType<ViewCupOnPlayer>();
        gameManager = FindObjectOfType<GameManager>();
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        soundsSettings = FindObjectOfType<SoundsSettings>();
        databaseManager = FindObjectOfType<DatabaseManager>();
    }
    private void InitPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("activeSkin"))
        {
            activeSkin = PlayerPrefs.GetInt("activeSkin");
        }
        for (int i = 0; i < arrayBuySkin.Length; i++)
        {
            string arrayNumberBuySkin = "arrayBuySkin" + i.ToString();
            if (PlayerPrefs.HasKey(arrayNumberBuySkin))
            {
                arrayBuySkin[i] = PlayerPrefs.GetInt(arrayNumberBuySkin);
            }
        }
    }
    private void Start()
    {
        ButtonPutSkinStart(activeSkin);
    }
    public void SavePlayerPrefsActiveSkin()
    {
        PlayerPrefs.SetInt("activeSkin", activeSkin);
        PlayerPrefs.Save();
    }
    public void SavePlayerPrefsArrayBuySkin(int index)
    {
        string arrayNumberBuySkin = "arrayBuySkin" + arrayBuySkin[index].ToString();
        PlayerPrefs.SetInt(arrayNumberBuySkin, arrayBuySkin[index]);
        PlayerPrefs.Save();
    }
    public void ButtonSkin(int index)
    {
        ActiveImgButton(index);
        ActiveImgSkin(index);
        ActiveBuyButton(index);
        soundsSettings.PlaySoundButton();
    }
    //смена картинки у кнопки
    private void ActiveImgButton(int index)
    {
        for (int i = 0; i < imgButtons.Length; i++)
        {
            if (i == index)
            {
                imgButtons[index].sprite = spriteButtonOn;
            }
            else
            {
                imgButtons[i].sprite = spriteButtonOff;
            }
        }
    }
    //смена картинки персонажа в магазине
    private void ActiveImgSkin(int index)
    {
        for (int i = 0; i < animatorControllerSkin.Length; i++)
        {
            if (i == index)
            {
                animatorSkinShop.runtimeAnimatorController = animatorControllerSkin[index];
            }
        }
    }

    //активна кнопка покупки или кнопка выбрать или текст "уже купленно" 
    private void ActiveBuyButton(int index)
    {
        if (arrayBuySkin[index] == 1 && activeSkin == index)
        {
            buySkinText[index].SetActive(true);
            for (int i = 0; i < buySkinPutButton.Length; i++)
            {
                buySkinPutButton[i].SetActive(false);
            }
            for (int i = 0; i < buySkinPutButton.Length; i++)
            {
                buySkinButton[i].SetActive(false);
            }
        }
        else if (arrayBuySkin[index] == 0)
        {
            buySkinButton[index].SetActive(true);
            for (int i = 0; i < buySkinPutButton.Length; i++)
            {
                buySkinPutButton[i].SetActive(false);
            }
            for (int i = 0; i < buySkinText.Length; i++)
            {
                buySkinText[i].SetActive(false);
            }
        }
        else if (arrayBuySkin[index] == 1 && activeSkin != index)
        {
            buySkinPutButton[index].SetActive(true);
            for (int i = 0; i < buySkinPutButton.Length; i++)
            {
                buySkinButton[i].SetActive(false);
            }
            for (int i = 0; i < buySkinPutButton.Length; i++)
            {
                buySkinText[i].SetActive(false);
            }
        }
    }

    // нопка купить скин
    public void ButtonBuySkin(int index)
    {
        if (gameManager._playerCoins >= arrayPriceOfSkins[index] )
        {
            soundsSettings.PlaySoundButton();
            UseCoinsForSkins(index);
            uILogicTopBar.TextCoinsTopBarPanel();

            arrayBuySkin[index] = index;
            SavePlayerPrefsArrayBuySkin(index);

            ButtonPutSkin(index);

            databaseManager.SaveStatsDB();
        }
        else
        {
            uILogicTopBar.AddCoinsPanelIsActiveTrue();
        }
    }
    public void UseCoinsForSkins(int index)
    {
        gameManager._playerCoins -= arrayPriceOfSkins[index];
        gameManager.SavePlayerPrefsCoins();
    }
    public void ButtonPutSkin(int index)
    {
        soundsSettings.PlaySoundButton();
        activeSkin = index;
        SavePlayerPrefsActiveSkin();
        ActiveBuyButton(index);

        animatorPlayer.runtimeAnimatorController = animatorControllersPlayer[index];

        viewCupOnPlayer.cups[0] = cupsForward[index];
        viewCupOnPlayer.cups[1] = cupsLeft[index];
        viewCupOnPlayer.cups[2] = cupsRight[index];
    }
    public void ButtonPutSkinStart(int index)
    {
        activeSkin = index;
        SavePlayerPrefsActiveSkin();
        ActiveBuyButton(index);

        animatorPlayer.runtimeAnimatorController = animatorControllersPlayer[index];

        viewCupOnPlayer.cups[0] = cupsForward[index];
        viewCupOnPlayer.cups[1] = cupsLeft[index];
        viewCupOnPlayer.cups[2] = cupsRight[index];
    }
}
