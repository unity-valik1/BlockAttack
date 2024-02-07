using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllBlocks : MonoBehaviour
{
    Block[] block;
    Bomb bomb;
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        bomb = GetComponent<Bomb>();
    }
    public void DestroyAllBlocksOnTheScene()
    {
        block = FindObjectsOfType<Block>();
        bomb.blockCount = block.Length;
        for (int i = 0; i < block.Length; i++)
        {
            block[i].BlockAnimDeleteBomb();
            Destroy(block[i].gameObject);
        }
    }
}
