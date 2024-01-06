using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAllGameObjects : MonoBehaviour
{
    ChangesColorBlock[] changesColorBlock;
    StandardBlock[] standardBlock;
    StaticBlock[] staticBlocks;
    BlockAnimDelete[] blockAnimDeletes;
    StarAnim[] starAnims;
    CoinsAnim[] coinsAnims;
    BrokenHeartAnim[] brokenHeartAnims;
    
    //CFX_AutoDestructShuriken[] cFX_AutoDestructShurikens;

    public void PauseAll()
    {
        PauseAllChangesColorBlockOnTheScene();
        PauseAllStandardBlockOnTheScene();
        PauseAllStaticBlocksOnTheScene();
        PauseAllBlockAnimDeleteOnTheScene();
        PauseAllStarAnimOnTheScene();
        PauseAllCoinsAnimsOnTheScene();
        PauseAllBrokenHeartAnimOnTheScene();
        //PauseAllCFX_AutoDestructShurikenOnTheScene();
    }
    private void PauseAllChangesColorBlockOnTheScene()
    {
        changesColorBlock = FindObjectsOfType<ChangesColorBlock>();
        if (changesColorBlock != null)
        {
            for (int i = 0; i < changesColorBlock.Length; i++)
            {
                changesColorBlock[i].AnimChangesColorPause();
                changesColorBlock[i].AnimMoveBlockPause();
                changesColorBlock[i]._speedMove = 0;
            }
        }
    }
    private void PauseAllStandardBlockOnTheScene()
    {
        standardBlock = FindObjectsOfType<StandardBlock>();
        if (standardBlock != null)
        {
            for (int i = 0; i < standardBlock.Length; i++)
            {
                standardBlock[i].AnimMoveBlockPause();
                standardBlock[i]._speedMove = 0;
            }
        }
    }
    private void PauseAllStaticBlocksOnTheScene()
    {
        staticBlocks = FindObjectsOfType<StaticBlock>();
        if (staticBlocks != null)
        {
            for (int i = 0; i < staticBlocks.Length; i++)
            {
                staticBlocks[i]._speedMove = 0;
            }
        }
    }
    private void PauseAllBlockAnimDeleteOnTheScene()
    {
        blockAnimDeletes = FindObjectsOfType<BlockAnimDelete>();
        if (blockAnimDeletes != null)
        {
            for (int i = 0; i < blockAnimDeletes.Length; i++)
            {
                blockAnimDeletes[i].AnimBlockDeletePause();
            }
        }
    }
    private void PauseAllStarAnimOnTheScene()
    {
        starAnims = FindObjectsOfType<StarAnim>();
        if (starAnims != null)
        {
            for (int i = 0; i < starAnims.Length; i++)
            {
                starAnims[i].AnimStarPause();
            }
        }
    }
    private void PauseAllCoinsAnimsOnTheScene()
    {
        coinsAnims = FindObjectsOfType<CoinsAnim>();
        if (coinsAnims != null)
        {
            for (int i = 0; i < coinsAnims.Length; i++)
            {
                coinsAnims[i].AnimCoinPause();
            }
        }
    }
    private void PauseAllBrokenHeartAnimOnTheScene()
    {
        brokenHeartAnims = FindObjectsOfType<BrokenHeartAnim>();
        if (brokenHeartAnims != null)
        {
            for (int i = 0; i < brokenHeartAnims.Length; i++)
            {
                brokenHeartAnims[i].AnimBrokenHeartPause();
            }
        }
    }
    //private void PauseAllCFX_AutoDestructShurikenOnTheScene()
    //{
    //    cFX_AutoDestructShurikens = FindObjectsOfType<CFX_AutoDestructShuriken>();
    //    if (cFX_AutoDestructShurikens != null)
    //    {
    //        for (int i = 0; i < cFX_AutoDestructShurikens.Length; i++)
    //        {
    //            cFX_AutoDestructShurikens[i].
    //        }
    //    }
    //}
}
