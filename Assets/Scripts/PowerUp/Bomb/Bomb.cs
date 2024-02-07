using DG.Tweening;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    GameManager gameManager;
    AnimCameraEffectBomb animCameraEffectBomb;
    BoomSmoke boomSmoke;
    DestroyAllBlocks destroyAllBlocks;
    ExplosionEffect explosionEffect;
    BombSound bombSound;
    UILogicTopBar uILogicTopBar;
    UILogicsGame uILogicsGame;
    PauseAllGameObjects pauseAllGameObjects;
    GenerationBlocks generationBlocks;
    ClearGamePanel clearGamePanel;
    PlayAllGameObjects playAllGameObjects;
    //DatabaseManager databaseManager;

    [SerializeField] private GameObject particleAddBomb;
    [SerializeField] private GameObject buttonAddBomb;

    public int blockCount;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        gameManager = FindObjectOfType<GameManager>();
        animCameraEffectBomb = GetComponent<AnimCameraEffectBomb>();
        boomSmoke = GetComponent<BoomSmoke>();
        destroyAllBlocks = GetComponent<DestroyAllBlocks>();
        explosionEffect = GetComponent<ExplosionEffect>();
        bombSound = GetComponent<BombSound>();
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
        pauseAllGameObjects = FindObjectOfType<PauseAllGameObjects>();
        generationBlocks = FindObjectOfType<GenerationBlocks>();
        clearGamePanel = FindObjectOfType<ClearGamePanel>();
        playAllGameObjects = FindObjectOfType<PlayAllGameObjects>();
        //databaseManager = FindObjectOfType<DatabaseManager>();
    }

    public void Boom()
    {
        if (gameManager._playerBomb >= 1)
        {
            bombSound.PlaySoundBomb();
            UseBomb();
            uILogicsGame.TextGameAmountOfBomb();
            Sequence sequence = DOTween.Sequence().SetUpdate(true);
            sequence.AppendCallback(generationBlocks.ScriptEnabledFalse);
            sequence.AppendCallback(pauseAllGameObjects.PauseAll);
            sequence.AppendCallback(animCameraEffectBomb.AnimCamera);
            sequence.AppendCallback(boomSmoke.AnimBoomSmokeOn);
            sequence.AppendInterval(2.2f);
            sequence.AppendCallback(destroyAllBlocks.DestroyAllBlocksOnTheScene);
            sequence.AppendCallback(clearGamePanel.DestroyAllBomb);
            sequence.AppendCallback(playAllGameObjects.PlayAllBomb); 
            sequence.AppendInterval(0.2f);
            sequence.AppendCallback(explosionEffect.EffectExplosion);
            sequence.AppendInterval(0.2f);
            sequence.AppendCallback(explosionEffect.EffectExplosionRight);
            sequence.AppendInterval(0.2f);
            sequence.AppendCallback(explosionEffect.EffectExplosionLeft);
            sequence.AppendInterval(2.0f);
            sequence.AppendCallback(generationBlocks.ScriptEnabledTrue);
            sequence.AppendCallback(boomSmoke.AnimBoomSmokeOff);
            sequence.AppendCallback(AddScore);
            sequence.SetAutoKill(true);
        }
    }

    public void UseBomb()
    {
        gameManager._playerBomb--;
        uILogicTopBar.TextBombTopBarPanel();
        gameManager.SavePlayerPrefsBomb();

        //databaseManager.SaveStatsDB();

    }
    public void AddBomb()
    {
        gameManager._playerBomb++;
        Instantiate(particleAddBomb, buttonAddBomb.transform.position, Quaternion.identity);
        gameManager.SavePlayerPrefsBomb();

        //databaseManager.SaveStatsDB();

    }
    public void AddScore()
    {
        Score score = FindObjectOfType<Score>();
        blockCount *= 50;
        score.AddPoints(blockCount);
        blockCount = 0;
    }
}
