using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllBlocks : MonoBehaviour
{
    Block[] block;
    public void DestroyAllBlocksOnTheScene()
    {
        block = FindObjectsOfType<Block>();
        for (int i = 0; i < block.Length; i++)
        {
            Destroy(block[i].gameObject);
        }
    }
}
