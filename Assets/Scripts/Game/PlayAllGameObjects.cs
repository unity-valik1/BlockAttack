using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAllGameObjects : MonoBehaviour
{
    ChangesColorBlock[] changesColorBlock;
    StandardBlock[] standardBlock;
    StaticBlock[] staticBlocks;
    BlockAnimDelete[] blockAnimDeletes;
    StarAnim[] starAnims;
    CoinsAnim[] coinsAnims;
    BrokenHeartAnim[] brokenHeartAnims;

    //CFX_AutoDestructShuriken[] cFX_AutoDestructShurikens;

    public void PlayAll()
    {
        PlayAllChangesColorBlockOnTheScene();
        PlayAllStandardBlockOnTheScene();
        PlayAllStaticBlocksOnTheScene();
        PlayAllBlockAnimDeleteOnTheScene();
        PlayAllStarAnimOnTheScene();
        PlayAllCoinsAnimsOnTheScene();
        PlayAllBrokenHeartAnimOnTheScene();
        //PauseAllCFX_AutoDestructShurikenOnTheScene();
    }
    private void PlayAllChangesColorBlockOnTheScene()
    {
        changesColorBlock = FindObjectsOfType<ChangesColorBlock>();
        if (changesColorBlock != null)
        {
            for (int i = 0; i < changesColorBlock.Length; i++)
            {
                changesColorBlock[i].AnimChangesColorPlay();
                changesColorBlock[i].AnimMoveBlockPlay();
                changesColorBlock[i]._speedMove = 3.5f;
            }
        }
    }
    private void PlayAllStandardBlockOnTheScene()
    {
        standardBlock = FindObjectsOfType<StandardBlock>();
        if (standardBlock != null)
        {
            for (int i = 0; i < standardBlock.Length; i++)
            {
                standardBlock[i].AnimMoveBlockPlay();
                standardBlock[i]._speedMove = 3.5f;
            }
        }
    }
    private void PlayAllStaticBlocksOnTheScene()
    {
        staticBlocks = FindObjectsOfType<StaticBlock>();
        if (staticBlocks != null)
        {
            for (int i = 0; i < staticBlocks.Length; i++)
            {
                staticBlocks[i]._speedMove = 3.5f;
            }
        }
    }
    private void PlayAllBlockAnimDeleteOnTheScene()
    {
        blockAnimDeletes = FindObjectsOfType<BlockAnimDelete>();
        if (blockAnimDeletes != null)
        {
            for (int i = 0; i < blockAnimDeletes.Length; i++)
            {
                blockAnimDeletes[i].AnimBlockDeletePlay();
            }
        }
    }
    private void PlayAllStarAnimOnTheScene()
    {
        starAnims = FindObjectsOfType<StarAnim>();
        if (starAnims != null)
        {
            for (int i = 0; i < starAnims.Length; i++)
            {
                starAnims[i].AnimStarPlay();
            }
        }
    }
    private void PlayAllCoinsAnimsOnTheScene()
    {
        coinsAnims = FindObjectsOfType<CoinsAnim>();
        if (coinsAnims != null)
        {
            for (int i = 0; i < coinsAnims.Length; i++)
            {
                coinsAnims[i].AnimCoinPlay();
            }
        }
    }
    private void PlayAllBrokenHeartAnimOnTheScene()
    {
        brokenHeartAnims = FindObjectsOfType<BrokenHeartAnim>();
        if (brokenHeartAnims != null)
        {
            for (int i = 0; i < brokenHeartAnims.Length; i++)
            {
                brokenHeartAnims[i].AnimBrokenHeartPlay();
            }
        }
    }
    //private void PlayAllCFX_AutoDestructShurikenOnTheScene()
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
