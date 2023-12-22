using DG.Tweening;
using UnityEngine;

public class Health : MonoBehaviour
{
    Armor armor;
    LossGame lossGame;

    [SerializeField] private GameObject particleBrokenHeart;
    [SerializeField] private GameObject[] _lifesItems;

    [SerializeField] int lifes;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        armor = FindObjectOfType<Armor>();
        lossGame = FindObjectOfType<LossGame>();
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
        if(armor._isArmor == false)
        {
            Instantiate(particleBrokenHeart, transform.position, Quaternion.identity);
            lifes--;
            if (lifes <= 0)
            {
                lossGame.Loos();
                return;
            }
            AnimHealth(lifes);
            transform.position = new Vector2(0, 4f);
        }
        else if(armor._isArmor == true)
        {
            armor.ArmoreOff();
            Block block = collision.GetComponentInParent<Block>();
            Destroy(block.gameObject);
            //todo анимация ломающегося блока
        }
    }

    public void UpdateHealth()
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

    private void AnimHealth(int lifes)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_lifesItems[lifes].transform.DOScale(0f, 0.5f));
        sequence.AppendCallback(UpdateHealth);
    }
}

