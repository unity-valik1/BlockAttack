using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBlock : MonoBehaviour
{
    [SerializeField] float _speedMove;
    [SerializeField] GameObject _deadTrigger;
    [SerializeField] GameObject[] pickUp;
    void Update()
    {
        transform.Translate(-_speedMove * Time.deltaTime * transform.up);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block") || collision.CompareTag("BottomWall"))
        {
            Pickup();
            Destroy(gameObject);
        }
    }

    public void Pickup()
    {
        int randomPickUp = Random.Range(0, pickUp.Length);
        Instantiate(pickUp[randomPickUp], transform.position, Quaternion.identity);
    }
}

