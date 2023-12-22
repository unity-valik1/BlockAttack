using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;

    public void EffectExplosion()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
    }
    public void EffectExplosionRight()
    {
        Instantiate(_explosionEffect, transform.position + new Vector3(-7,0,0), Quaternion.identity);
    }
    public void EffectExplosionLeft()
    {
        Instantiate(_explosionEffect, transform.position + new Vector3(7, 0, 0), Quaternion.identity);
    }
}
