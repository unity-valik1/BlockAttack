using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGamePanel : MonoBehaviour
{
    ChangesColorBlock[] changesColorBlock;
    StandardBlock[] standardBlock;
    StaticBlock[] staticBlocks;
    BlockAnimDelete[] blockAnimDeletes;
    StarAnim[] starAnims;
    CoinsAnim[] coinsAnims;
    BrokenHeartAnim[] brokenHeartAnims;
    CFX_AutoDestructShuriken[] cFX_AutoDestructShurikens;
    PickAnimRight[] pickAnimRight;
    PickAnimLeft[] pickAnimLeft;

    public void DestroyAll()
    {
        DestroyAllChangesColorBlockOnTheScene();
        DestroyAllStandardBlockOnTheScene();
        DestroyAllStaticBlocksOnTheScene();
        DestroyAllBlockAnimDeleteOnTheScene();
        DestroyAllStarAnimOnTheScene();
        DestroyAllCoinsAnimsOnTheScene();
        DestroyAllBrokenHeartAnimOnTheScene();
        DestroyAllCFX_AutoDestructShurikenOnTheScene();
        DestroyAllPickAnimRightOnTheScene();
        DestroyAllPickAnimLeftOnTheScene();
    }
    private void DestroyAllChangesColorBlockOnTheScene()
    {
        changesColorBlock = FindObjectsOfType<ChangesColorBlock>();
        if (changesColorBlock != null)
        {
            for (int i = 0; i < changesColorBlock.Length; i++)
            {
                changesColorBlock[i].AnimChangesColorFalse();
                changesColorBlock[i].AnimMoveBlockFalse();
                Destroy(changesColorBlock[i].gameObject);
            }
        }
    }
    private void DestroyAllStandardBlockOnTheScene()
    {
        standardBlock = FindObjectsOfType<StandardBlock>();
        if (standardBlock != null)
        {
            for (int i = 0; i < standardBlock.Length; i++)
            {
                standardBlock[i].AnimMoveBlockFalse();
                Destroy(standardBlock[i].gameObject);
            }
        }
    }
    private void DestroyAllStaticBlocksOnTheScene()
    {
        staticBlocks = FindObjectsOfType<StaticBlock>();
        if (staticBlocks != null)
        {
            for (int i = 0; i < staticBlocks.Length; i++)
            {
                Destroy(staticBlocks[i].gameObject);
            }
        }
    }
    private void DestroyAllBlockAnimDeleteOnTheScene()
    {
        blockAnimDeletes = FindObjectsOfType<BlockAnimDelete>();
        if (blockAnimDeletes != null)
        {
            for (int i = 0; i < blockAnimDeletes.Length; i++)
            {
                blockAnimDeletes[i].AnimBlockDeleteFalse();
                Destroy(blockAnimDeletes[i].gameObject);
            }
        }
    }
    private void DestroyAllStarAnimOnTheScene()
    {
        starAnims = FindObjectsOfType<StarAnim>();
        if (starAnims != null)
        {
            for (int i = 0; i < starAnims.Length; i++)
            {
                starAnims[i].AnimStarFalse();
                Destroy(starAnims[i].gameObject);
            }
        }
    }
    private void DestroyAllCoinsAnimsOnTheScene()
    {
        coinsAnims = FindObjectsOfType<CoinsAnim>();
        if (coinsAnims != null)
        {
            for (int i = 0; i < coinsAnims.Length; i++)
            {
                coinsAnims[i].AnimCoinFalse();
                Destroy(coinsAnims[i].gameObject);
            }
        }
    }
    private void DestroyAllBrokenHeartAnimOnTheScene()
    {
        brokenHeartAnims = FindObjectsOfType<BrokenHeartAnim>();
        if (brokenHeartAnims != null)
        {
            for (int i = 0; i < brokenHeartAnims.Length; i++)
            {
                brokenHeartAnims[i].AnimBrokenHeartFalse();
                Destroy(brokenHeartAnims[i].gameObject);
            }
        }
    }
    private void DestroyAllCFX_AutoDestructShurikenOnTheScene()
    {
        cFX_AutoDestructShurikens = FindObjectsOfType<CFX_AutoDestructShuriken>();
        if (cFX_AutoDestructShurikens != null)
        {
            for (int i = 0; i < cFX_AutoDestructShurikens.Length; i++)
            {
                Destroy(cFX_AutoDestructShurikens[i].gameObject);
            }
        }
    }
    private void DestroyAllPickAnimRightOnTheScene()
    {
        pickAnimRight = FindObjectsOfType<PickAnimRight>();
        if (pickAnimRight != null)
        {
            for (int i = 0; i < pickAnimRight.Length; i++)
            {
                pickAnimRight[i].PickAnimRightFalse();
                Destroy(pickAnimRight[i].gameObject);
            }
        }
    }
    private void DestroyAllPickAnimLeftOnTheScene()
    {
        pickAnimLeft = FindObjectsOfType<PickAnimLeft>();
        if (pickAnimLeft != null)
        {
            for (int i = 0; i < pickAnimLeft.Length; i++)
            {
                pickAnimLeft[i].PickAnimLeftFalse();
                Destroy(pickAnimLeft[i].gameObject);
            }
        }
    }
}
