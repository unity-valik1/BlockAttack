using UnityEngine;

public class Block : MonoBehaviour
{

    AudioSource audioSource;
    public SpriteRenderer sr;

    [SerializeField] private GameObject blockAnimDelete;

    public int _numberBlock;

    public bool isFall = true;
    public bool _isDelete = false;
    public bool _isMove = false;


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void BlockAnimDelete()
    {
        GameObject go = Instantiate(blockAnimDelete, transform.position, Quaternion.identity);
        go.GetComponent<SpriteRenderer>().sprite = sr.sprite;
    }
    public void BlockAnimDeleteBomb()
    {
        GameObject go = Instantiate(blockAnimDelete, transform.position, Quaternion.identity);
        go.GetComponent<SpriteRenderer>().sprite = sr.sprite;
        go.GetComponent<BlockAnimDelete>().animDeleteView = false;
    }
    public void PlaySoundBlocksDestroy()
    {
        SoundsSettings soundsSettings = FindObjectOfType<SoundsSettings>();
        if (soundsSettings._isActiveSounds == 1)
        {
            audioSource.Play();
        }
    }
    public void GameMode(int numberBlock)
    {
        GenerationBlocks generationBlocks = FindObjectOfType<GenerationBlocks>();
        if (generationBlocks.gameMode == 1)
        {
            LevelMissions levelMissions = FindObjectOfType<LevelMissions>();
            levelMissions.MinusBlock(numberBlock);
        }
    }
}
