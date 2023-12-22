using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAnim : MonoBehaviour
{
    Animation anim;

    public GameObject particleEffectPrefab;
    public GameObject particleStar;

    private void Start()
    {
        Init();
        anim.Play();
        Invoke("ParticleEffect", 0.9f);
        Destroy(gameObject, 1f);
    }
    private void Init()
    {
        anim = GetComponent<Animation>();
    }
    private void ParticleEffect()
    {
        Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        Instantiate(particleStar, transform.position, Quaternion.identity);
    }
}
