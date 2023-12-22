using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    PictureArmorOnThePlayer pictureArmorOnThePlayer;

    public bool _isArmor = false;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        pictureArmorOnThePlayer = FindObjectOfType<PictureArmorOnThePlayer>();
    }

    public void ArmorIsActive()
    {
        if (_isArmor == false)
        {
            ArmoreOn();
            pictureArmorOnThePlayer.PictureArmorIsActive();
        }
        else
        {
            //todo броня активна
        }
    }

    public void ArmoreOn()
    {
        _isArmor = true;
    }

    public void ArmoreOff()
    {
        _isArmor = false;
    }
}
