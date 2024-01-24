using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCupOnPlayer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite[] cups;



    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
}
