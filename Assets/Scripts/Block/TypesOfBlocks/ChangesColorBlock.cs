using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangesColorBlock : MonoBehaviour
{
    Block block;

    [SerializeField] private Animation anim;
    public SpriteRenderer animBlock;
    public GameObject animBlockGO;
    public Sprite[] _imgsBlock;

    [SerializeField] GameObject deadTrigger;

    public float _speedMove;

    public bool _isMove = false;

    public List<Block> blocksCollectedLine = new();
    public List<Block> identicalBlocksHorizontal = new();
    public List<Block> identicalBlocksVertical = new();
    public List<Block> identicalBlocksHorizontalAndVertical = new();
    public List<Block> blocksDelete = new();

    [SerializeField] private int _pointsIdenticalBlocks;
    [SerializeField] private int _pointsCollectedLine;
    [SerializeField] private int _coinsIdenticalBlocks;
    [SerializeField] private int _coinsCollectedLine;

    [SerializeField] private int _newNumberBlock;

    [SerializeField] float _timeInterval;
    private float _time = 0f;

    Tween tweenChangesColor;
    Tween tweenMoveBlock;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        block = GetComponent<Block>();
    }

    private void Start()
    {
        RandomChangesColor();
    }
    void Update()
    {
        if (block.isFall)
        {
            transform.Translate(-_speedMove * Time.deltaTime * transform.up);
            RunRayFall();
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0.15f, 0.6f, 0), transform.right - new Vector3(0.7f, 0, 0), 0.3f);
        if (hit == false)
        {
            block.isFall = true;
            _isMove = false;
        }

        _time += Time.deltaTime;
        if (_time >= _timeInterval)
        {
            _time = 0;
            if(block._isDelete == false)
            {
                UpdateChangesColorAndChecks();
            }
        }
    }

    void RandomChangesColor()
    {
        int colorBlock = Random.Range(0, _imgsBlock.Length);
        block._numberBlock = colorBlock;
        block.sr.sprite = _imgsBlock[colorBlock];
    }
    void UpdateChangesColorAndChecks()
    {
        _newNumberBlock = Random.Range(0, _imgsBlock.Length);
        for (int i = 0; i < _imgsBlock.Length; i++)
        {
            if (_newNumberBlock == block._numberBlock)
            {
                _newNumberBlock = Random.Range(0, _imgsBlock.Length);
                i = -1;
            }
            else
            {
                if (block._isDelete == true)
                {
                    return;
                }
                else
                {
                    StartAnimChangesColorAndNumber();
                    Sequence sequence = DOTween.Sequence();
                    tweenChangesColor = sequence;
                    sequence.Append(animBlockGO.transform.DORotate(new Vector3(90, 0, 0), 0.15f, RotateMode.Fast));
                    sequence.AppendCallback(MidAnimChangesNewColor);
                    sequence.Append(animBlockGO.transform.DORotate(new Vector3(0, 0, 0), 0.15f, RotateMode.Fast));
                    sequence.AppendCallback(EndAnimChangesNewColorAndNumber);
                    return;
                }
            }
        }
    }
    void StartAnimChangesColorAndNumber()
    {
        if (block._isDelete == true)
        {
            animBlock.enabled = false;
        }
        else
        {
            animBlock.sprite = _imgsBlock[block._numberBlock];
            block._numberBlock = -1;
            block.sr.enabled = false;
            animBlock.enabled = true;
        }
    }
    void MidAnimChangesNewColor()
    {
        if (block._isDelete == true)
        {
            animBlock.enabled = false;
        }
        else
        {
            animBlock.sprite = _imgsBlock[_newNumberBlock];
        }
    }
    void EndAnimChangesNewColorAndNumber()
    {
        if (block._isDelete == true)
        {
            animBlock.enabled = false;
        }
        else
        {
            block.sr.sprite = _imgsBlock[_newNumberBlock];
            block._numberBlock = _newNumberBlock;
            block.sr.enabled = true;
            animBlock.enabled = false;
            Checks();
        }
    }
    public void AnimChangesColorFalse()
    {
        tweenChangesColor.Kill();
    }
    public void AnimChangesColorPause()
    {
        tweenChangesColor.Pause();
    }
    public void AnimChangesColorPlay()
    {
        tweenChangesColor.Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_isMove && transform.position.x != -7.5f || _isMove && transform.position.x != 7.5f)
            {
                _isMove = false;

                if (collision.transform.position.x > transform.position.x)
                {
                    bool ray_1_Collision = RunRayMove(transform.position - new Vector3(0.5f, 0.45f, 0), -transform.right, 0.5f);//слева
                    bool ray_2_Collision = RunRayMove(transform.position + new Vector3(-0.5f, 1.4f, 0), transform.right, 1f);//вверху
                    bool ray_3_Collision = RunRayMove(transform.position - new Vector3(1f, 0, 0), new Vector3(-0.5f, 2.25f, 0), 2.25f);//слева-наискосок
                    if (ray_1_Collision && ray_2_Collision && ray_3_Collision)
                    {
                        MoveActive(-1);
                    }
                    else
                    {
                        _isMove = true;
                    }
                }
                else if (collision.transform.position.x < transform.position.x)
                {
                    bool ray_1_Collision = RunRayMove(transform.position + new Vector3(0.5f, -0.45f, 0), transform.right, 0.5f);//справа
                    bool ray_2_Collision = RunRayMove(transform.position + new Vector3(-0.5f, 1.4f, 0), transform.right, 1f);//вверху
                    bool ray_3_Collision = RunRayMove(transform.position + new Vector3(1f, 0, 0), new Vector3(0.5f, 2.25f, 0), 2.25f);//справа-наискосок
                    if (ray_1_Collision && ray_2_Collision && ray_3_Collision)
                    {
                        MoveActive(1);
                    }
                    else
                    {
                        _isMove = true;
                    }
                }
            }
        }
    }

    IEnumerator FinishMove()
    {
        yield return new WaitForSeconds(0.3f);
        RunRayFall();
    }
    void MoveActive(int number)
    {
        tweenMoveBlock = transform.DOMoveX(transform.position.x + number, 0.3f).SetEase(Ease.Linear);
        StartCoroutine(FinishMove());
    }
    bool RunRayMove(Vector2 startPos, Vector2 endPos, float distanse)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(startPos, endPos, distanse);

        if (hits.Length > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void AnimMoveBlockFalse()
    {
        tweenMoveBlock.Kill();
    }
    public void AnimMoveBlockPause()
    {
        tweenMoveBlock.Pause();
    }
    public void AnimMoveBlockPlay()
    {
        tweenMoveBlock.Play();
    }

    void RunRayFall()
    {
        RaycastHit2D hits = Physics2D.Raycast(transform.position - new Vector3(0.15f, 0.7f, 0), transform.right - new Vector3(0.7f, 0, 0), 0.3f);

        if (hits == false)
        {
            block.isFall = true;
            _isMove = false;
        }
        else
        {
            //if (hits.collider.CompareTag("PickUpHeart") || hits.collider.CompareTag("PickUpCoin") || hits.collider.CompareTag("PickUpStar"))
            //{
            //    Destroy(hits.collider.gameObject);
            //}
            if (deadTrigger != null)
            {
                Destroy(deadTrigger, 0.1f);
            }
            if (hits.collider.CompareTag("Block"))
            {
                block.isFall = false;
                transform.position = hits.transform.position + Vector3.up;
            }
            else if (hits.collider.CompareTag("BottomWall"))
            {
                block.isFall = false;
                transform.position = new Vector2(transform.position.x, -2.5f);
            }

            Checks();

            if (!block._isDelete)
            {
                block.isFall = false;
                _isMove = true;
            }
        }
    }

    void Checks()
    {
        if (block._isDelete == false/* && _isMove*/)
        {
            FindOdjGameLoos();
            FindCollectedLine();
            FindIdenticalBlockHorizontalAndVertical();
            DeleteBlocks();
        }
    }
    void FindOdjGameLoos()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position - new Vector3(0.5f, 0, 0), -transform.right, 15.5f);
        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.CompareTag("CheckingGameLoss"))
                {
                    hits[i].collider.GetComponent<CheckingGameLoss>().ActiveRay();
                    break;
                }
            }
        }
    }
    private void FindCollectedLine()
    {
        RaycastHit2D[] hitsLeft = Physics2D.RaycastAll(transform.position - new Vector3(0.5f, 0, 0), -transform.right, 15.5f);
        blocksCollectedLine.Clear();
        if (hitsLeft != null)
        {
            for (int i = 0; i < hitsLeft.Length; i++)
            {
                if (hitsLeft[i].collider.CompareTag("Block"))
                {
                    Block block = hitsLeft[i].collider.GetComponent<Block>();
                    Transform transform = hitsLeft[i].collider.GetComponent<Transform>();
                    if (transform.position.y == this.transform.position.y && block._isDelete == false)
                    {
                        blocksCollectedLine.Add(block);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        RaycastHit2D[] hitsRight = Physics2D.RaycastAll(transform.position + new Vector3(0.5f, 0, 0), transform.right, 15.5f);
        if (hitsRight != null)
        {
            for (int i = 0; i < hitsRight.Length; i++)
            {
                if (hitsRight[i].collider.CompareTag("Block"))
                {
                    Block block = hitsRight[i].collider.GetComponent<Block>();
                    Transform transform = hitsRight[i].collider.GetComponent<Transform>();
                    if (transform.position.y == this.transform.position.y)
                    {
                        blocksCollectedLine.Add(block);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        if (blocksCollectedLine.Count == 15)
        {
            blocksCollectedLine.Add(block);
        }
    }
    private void FindIdenticalBlockHorizontalAndVertical()
    {
        RaycastHit2D[] hitsLeft = Physics2D.RaycastAll(transform.position - new Vector3(0.5f, 0.1f, 0), -transform.right, 13.5f);
        identicalBlocksHorizontal.Clear();
        if (hitsLeft != null)
        {
            for (int i = 0; i < hitsLeft.Length; i++)
            {
                if (hitsLeft[i].collider.CompareTag("Block"))
                {
                    Block otherblock = hitsLeft[i].collider.GetComponent<Block>();
                    Transform transform = hitsLeft[i].collider.GetComponent<Transform>();
                    if (transform.position.x == this.transform.position.x - (i + 1) &&
                        transform.position.y == this.transform.position.y &&
                        otherblock._numberBlock == block._numberBlock &&
                        otherblock._isDelete == false)
                    {
                        identicalBlocksHorizontal.Add(otherblock);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        RaycastHit2D[] hitsRight = Physics2D.RaycastAll(transform.position + new Vector3(0.5f, -0.1f, 0), transform.right, 13.5f);
        if (hitsRight != null)
        {
            for (int i = 0; i < hitsRight.Length; i++)
            {
                if (hitsRight[i].collider.CompareTag("Block"))
                {
                    Block otherblock = hitsRight[i].collider.GetComponent<Block>();
                    Transform transform = hitsRight[i].collider.GetComponent<Transform>();
                    if (transform.position.x == this.transform.position.x + (i + 1) &&
                        transform.position.y == this.transform.position.y &&
                        otherblock._numberBlock == block._numberBlock &&
                        otherblock._isDelete == false)
                    {
                        identicalBlocksHorizontal.Add(otherblock);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        RaycastHit2D[] hitsDown = Physics2D.RaycastAll(transform.position - new Vector3(0f, 0.5f, 0), -transform.up, 5.5f);
        identicalBlocksVertical.Clear();
        if (hitsDown != null)
        {
            for (int i = 0; i < hitsDown.Length; i++)
            {
                if (hitsDown[i].collider.CompareTag("Block"))
                {
                    Block otherblock = hitsDown[i].collider.GetComponent<Block>();
                    Transform transform = hitsDown[i].collider.GetComponent<Transform>();
                    if (otherblock._numberBlock == block._numberBlock &&
                        transform.position.y == this.transform.position.y - (i + 1) &&
                        otherblock._isDelete == false)
                    {
                        identicalBlocksVertical.Add(otherblock);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        RaycastHit2D[] hitsUp = Physics2D.RaycastAll(transform.position + new Vector3(0f, 0.5f, 0), transform.up, 5.5f);
        if (hitsUp != null)
        {
            for (int i = 0; i < hitsUp.Length; i++)
            {
                if (hitsUp[i].collider.CompareTag("Block"))
                {
                    Block otherblock = hitsUp[i].collider.GetComponent<Block>();
                    Transform transform = hitsUp[i].collider.GetComponent<Transform>();
                    if (otherblock._numberBlock == block._numberBlock &&
                        transform.position.y == this.transform.position.y + (i + 1) &&
                        otherblock._isDelete == false)
                    {
                        identicalBlocksVertical.Add(otherblock);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        if (identicalBlocksHorizontal.Count >= 2 && identicalBlocksVertical.Count >= 2)
        {
            identicalBlocksHorizontalAndVertical.Add(block);
            for (int i = 0; i < identicalBlocksHorizontal.Count; i++)
            {
                identicalBlocksHorizontalAndVertical.Add(identicalBlocksHorizontal[i]);
            }
            for (int i = 0; i < identicalBlocksVertical.Count; i++)
            {
                identicalBlocksHorizontalAndVertical.Add(identicalBlocksVertical[i]);
            }
        }
        else if (identicalBlocksHorizontal.Count >= 2)
        {
            identicalBlocksHorizontalAndVertical.Add(block);
            for (int i = 0; i < identicalBlocksHorizontal.Count; i++)
            {
                identicalBlocksHorizontalAndVertical.Add(identicalBlocksHorizontal[i]);
            }
        }
        else if (identicalBlocksVertical.Count >= 2)
        {
            identicalBlocksHorizontalAndVertical.Add(block);
            for (int i = 0; i < identicalBlocksVertical.Count; i++)
            {
                identicalBlocksHorizontalAndVertical.Add(identicalBlocksVertical[i]);
            }
        }
    }
    void DeleteBlocks()
    {
        int points = 0;
        int money = 0;
        if (blocksCollectedLine.Count == 16 && identicalBlocksHorizontalAndVertical.Count >= 3)
        {
            for (int i = 0; i < blocksCollectedLine.Count; i++)
            {
                blocksDelete.Add(blocksCollectedLine[i]);
            }
            points += _pointsCollectedLine;
            money += _coinsCollectedLine;
            for (int i = 0; i < identicalBlocksHorizontalAndVertical.Count; i++)
            {
                blocksDelete.Add(identicalBlocksHorizontalAndVertical[i]);
                points += _pointsIdenticalBlocks;
                money += _coinsIdenticalBlocks;
            }
        }
        else if (blocksCollectedLine.Count == 16)
        {
            for (int i = 0; i < blocksCollectedLine.Count; i++)
            {
                blocksDelete.Add(blocksCollectedLine[i]);
            }
            points += _pointsCollectedLine;
            money += _coinsCollectedLine;
        }
        else if (identicalBlocksHorizontalAndVertical.Count >= 3)
        {
            for (int i = 0; i < identicalBlocksHorizontalAndVertical.Count; i++)
            {
                blocksDelete.Add(identicalBlocksHorizontalAndVertical[i]);
                points += _pointsIdenticalBlocks;
                money += _coinsIdenticalBlocks;
            }
        }
        if (points != 0)
        {
            Score score = FindObjectOfType<Score>();
            score.AddPoints(points);
            Coins coins = FindObjectOfType<Coins>();
            coins.AddCoinsGame(money);
            for (int k = 0; k < blocksDelete.Count; k++)
            {
                if (blocksDelete[k] != null || blocksDelete[k] == null)
                {
                    blocksDelete[k]._isDelete = true;
                    blocksDelete[k].BlockAnimDelete();
                    blocksDelete[k].sr.enabled = false;
                    Destroy(blocksDelete[k].gameObject, 1f);
                }
            }
            block.PlaySoundBlocksDestroy();
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + new Vector3(-0.5f, 1.4f, 0), transform.right, Color.yellow);//вверху

        Debug.DrawRay(transform.position - new Vector3(0.5f, 0.45f, 0), -transform.right + new Vector3(0.5f, 0, 0), Color.red);//слева
        Debug.DrawRay(transform.position - new Vector3(1f, -0.1f, 0), new Vector3(0f, 2.25f, 0), Color.green);//слева-наискосок

        Debug.DrawRay(transform.position + new Vector3(0.5f, -0.45f, 0), transform.right - new Vector3(0.5f, 0, 0), Color.red);//справа
        Debug.DrawRay(transform.position + new Vector3(1f, 0.1f, 0), new Vector3(0f, 2.25f, 0), Color.green);//справа-наискосок

        Debug.DrawRay(transform.position - new Vector3(0.15f, 0.6f, 0), transform.right - new Vector3(0.7f, 0, 0), Color.black);//снизу

        Debug.DrawRay(transform.position - new Vector3(0.5f, 0, 0), -transform.right - new Vector3(13.5f, 0, 0), Color.green);//поиск проверки линии
        Debug.DrawRay(transform.position + new Vector3(0.5f, 0, 0), transform.right + new Vector3(13.5f, 0, 0), Color.green);//поиск проверки линии

        Debug.DrawRay(transform.position - new Vector3(0.5f, 0.1f, 0), -transform.right - new Vector3(13.5f, 0, 0), Color.magenta);//поиск одинаковых блоков слева
        Debug.DrawRay(transform.position + new Vector3(0.5f, -0.1f, 0), transform.right + new Vector3(13.5f, 0, 0), Color.magenta);//поиск одинаковых блоков справа
        Debug.DrawRay(transform.position - new Vector3(0, 0.5f, 0), -transform.up - new Vector3(0, 5.5f, 0), Color.magenta);//поиск одинаковых блоков снизу

    }
}
