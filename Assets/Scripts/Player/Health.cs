using DG.Tweening;
using UnityEngine;

public class Health : MonoBehaviour
{
    Armor armor;
    UILogicsGame uILogicsGame;
    ArmorSound armorSound;
    SoundBrokenHeart soundBrokenHeart;
    Vibrations vibrations;

    [SerializeField] private GameObject particleBrokenHeart;

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
        vibrations = FindObjectOfType<Vibrations>();
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
            vibrations.Vibration();
            Instantiate(particleBrokenHeart, transform.position, Quaternion.identity);
            lifes--;
            if (lifes <= 0)
            {
                uILogicsGame.LossGamePanel();
                return;
            }
            uILogicsGame.AnimLossHealth(lifes);
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
}

