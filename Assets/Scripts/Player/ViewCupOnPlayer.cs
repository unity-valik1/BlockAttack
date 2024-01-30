using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCupOnPlayer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Movement movement;

    public Sprite[] cups;



    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<Movement>();
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ChangesCupFront()
    {
        spriteRenderer.sprite = cups[0];
    }
    public void ChangesCupLeft()
    {
        spriteRenderer.sprite = cups[1];
    }
    public void ChangesCupRight()
    {
        spriteRenderer.sprite = cups[2];
    }

    public void WhichSpeed()
    {
        if (movement._movement == 0)
        {
            ChangesCupFront();
        }
        else if(movement._movement == -1)
        {
            ChangesCupLeft();
        }
        else if(movement._movement == 1)
        {
            ChangesCupRight();
        }
    }
}
