using DG.Tweening;
using UnityEngine;

public class Health : MonoBehaviour
{
    Armor armor;
    UILogicsGame uILogicsGame;
    ArmorSound armorSound;
    SoundBrokenHeart soundBrokenHeart;

    [SerializeField] private GameObject particleBrokenHeart;
    [SerializeField] private GameObject[] _lifesItems;

    public int lifes;
    public int maxLifes;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        armor = FindObjectOfType<Armor>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
        armorSound = FindObjectOfType<ArmorSound>();
        soundBrokenHeart = FindObjectOfType<SoundBrokenHeart>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BlockAttack"))
        {
            LoseHealth(collision);
        }
    }

    private void LoseHealth(Collider2D collision)
    {
        if (armor._isArmor == false)
        {
            soundBrokenHeart.PlaySoundBrokenHeart();
            Instantiate(particleBrokenHeart, transform.position, Quaternion.identity);
            lifes--;
            if (lifes <= 0)
            {
                uILogicsGame.LossGamePanel();
                return;
            }
            AnimLossHealth(lifes);
            transform.position = new Vector2(0, 4f);
        }
        else if (armor._isArmor == true)
        {
            armorSound.PlaySoundArmoreIsActiveFalse();
            armor.ArmoreOff();
            Block block = collision.GetComponentInParent<Block>();
            Destroy(block.gameObject);
            armor.imgPlayerArmor.SetActive(false);
            //todo анимация ломающегося блока
        }
    }

    public void UpdateAddHealth(int health)
    {
        lifes = health;
        for (int i = 0; i < _lifesItems.Length; i++)
        {
            if (i < lifes)
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

    public void UpdateHealthInGame()
    {
        for (int i = 0; i < _lifesItems.Length; i++)
        {
            if (i < lifes)
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
    public void AnimAddHealth(int lifes)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(UpdateHealthInGame);
        sequence.Append(_lifesItems[lifes].transform.DOScale(1, 0.5f));
    }
}

