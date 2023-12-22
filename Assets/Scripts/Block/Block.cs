using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;

public class Block : MonoBehaviour
{
    Score score;
    SpriteRenderer sr;

    [SerializeField] private GameObject prefab;
    [SerializeField] GameObject deadTrigger;

    [SerializeField] public int _numberBlock;

    [SerializeField] float _speedMove;

    public bool isFall = true;
    public bool _isMove = false;
    public bool _isDelete = false;

    public List<Block> blocksCollectedLine = new();
    public List<Block> identicalBlocksHorizontal = new();
    public List<Block> identicalBlocksVertical = new();
    public List<Block> identicalBlocksHorizontalAndVertical = new();
    public List<Block> blocksDelete = new();

    [SerializeField] private int _pointsIdenticalBlocks;
    [SerializeField] private int _pointsCollectedLine;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        sr = GetComponent<SpriteRenderer>();
        score = FindObjectOfType<Score>();
    }

    void Update()
    {
        if (isFall)
        {
            transform.Translate(-_speedMove * Time.deltaTime * transform.up);
            RunRayFall();
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0.15f, 0.6f, 0), transform.right - new Vector3(0.7f, 0, 0), 0.3f);
        if (hit == false)
        {
            isFall = true;
            _isMove = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_isMove && transform.position.x != -7.5f || _isMove && transform.position.x != 7.5f )
            {
                _isMove = false;

                if (collision.transform.position.x > transform.position.x)
                {
                    bool ray_1_Collision = RunRayMove(transform.position - new Vector3(0.5f, 0, 0), -transform.right, 0.5f);//слева
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
                    bool ray_1_Collision = RunRayMove(transform.position + new Vector3(0.5f, 0, 0), transform.right, 0.5f);//справа
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
        transform.DOMoveX(transform.position.x + number, 0.3f).SetEase(Ease.Linear);
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

    void RunRayFall()
    {
        RaycastHit2D hits = Physics2D.Raycast(transform.position - new Vector3(0.15f, 0.7f, 0), transform.right - new Vector3(0.7f, 0, 0), 0.3f);

        if (hits == false)
        {
            isFall = true;
            _isMove = false;
        }
        else
        {
            if (deadTrigger != null)
            {
                Destroy(deadTrigger, 0.1f);
            }
            if (hits.collider.CompareTag("Block"))
            {
                isFall = false;
                transform.position = hits.transform.position + Vector3.up;
                //_isMove = true;
            }
            else if (hits.collider.CompareTag("BottomWall"))
            {
                isFall = false;
                transform.position = new Vector2(transform.position.x, -2.5f);
                //_isMove = true;
            }
            if (!_isDelete)
            {
                FindOdjGameLoos();
                FindCollectedLine();
                FindIdenticalBlockHorizontalAndVertical();
                DeleteBlocks();
                if (!_isDelete)
                {
                    isFall = false;
                    _isMove = true;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + new Vector3(-0.5f, 1.4f, 0), transform.right, Color.yellow);//вверху

        Debug.DrawRay(transform.position - new Vector3(0.5f, -0.1f, 0), -transform.right + new Vector3(0.5f, 0, 0), Color.red);//слева
        Debug.DrawRay(transform.position - new Vector3(1f, -0.1f, 0), new Vector3(0f, 2.25f, 0), Color.green);//слева-наискосок

        Debug.DrawRay(transform.position + new Vector3(0.5f, 0.1f, 0), transform.right - new Vector3(0.5f, 0, 0), Color.red);//справа
        Debug.DrawRay(transform.position + new Vector3(1f, 0.1f, 0), new Vector3(0f, 2.25f, 0), Color.green);//справа-наискосок

        Debug.DrawRay(transform.position - new Vector3(0.15f, 0.6f, 0), transform.right - new Vector3(0.7f, 0, 0), Color.black);//снизу

        Debug.DrawRay(transform.position - new Vector3(0.5f, 0, 0), -transform.right - new Vector3(13.5f, 0, 0), Color.green);//поиск проверки линии
        Debug.DrawRay(transform.position + new Vector3(0.5f, 0, 0), transform.right + new Vector3(13.5f, 0, 0), Color.green);//поиск проверки линии

        Debug.DrawRay(transform.position - new Vector3(0.5f, 0.1f, 0), -transform.right - new Vector3(13.5f, 0, 0), Color.magenta);//поиск одинаковых блоков слева
        Debug.DrawRay(transform.position + new Vector3(0.5f, -0.1f, 0), transform.right + new Vector3(13.5f, 0, 0), Color.magenta);//поиск одинаковых блоков справа
        Debug.DrawRay(transform.position - new Vector3(0, 0.5f, 0), -transform.up - new Vector3(0, 5.5f, 0), Color.magenta);//поиск одинаковых блоков справа

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
            blocksCollectedLine.Add(this);
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
                    Block block = hitsLeft[i].collider.GetComponent<Block>();
                    Transform transform = hitsLeft[i].collider.GetComponent<Transform>();
                    if (transform.position.x == this.transform.position.x - (i + 1) && 
                        transform.position.y == this.transform.position.y && 
                        block._numberBlock == _numberBlock &&
                        block._isDelete == false)
                    {
                        identicalBlocksHorizontal.Add(block);
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
                    Block block = hitsRight[i].collider.GetComponent<Block>();
                    Transform transform = hitsRight[i].collider.GetComponent<Transform>();
                    if (transform.position.x == this.transform.position.x + (i + 1) && 
                        transform.position.y == this.transform.position.y && 
                        block._numberBlock == _numberBlock &&
                        block._isDelete == false)
                    {
                        identicalBlocksHorizontal.Add(block);
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
                    Block block = hitsDown[i].collider.GetComponent<Block>();
                    Transform transform = hitsDown[i].collider.GetComponent<Transform>();
                    if (block._numberBlock == _numberBlock && 
                        transform.position.y == this.transform.position.y - (i + 1) &&
                        block._isDelete == false)
                    {
                        identicalBlocksVertical.Add(block);
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
            identicalBlocksHorizontalAndVertical.Add(this);
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
            identicalBlocksHorizontalAndVertical.Add(this);
            for (int i = 0; i < identicalBlocksHorizontal.Count; i++)
            {
                identicalBlocksHorizontalAndVertical.Add(identicalBlocksHorizontal[i]);
            }
        }
        else if (identicalBlocksVertical.Count >= 2)
        {
            identicalBlocksHorizontalAndVertical.Add(this);
            for (int i = 0; i < identicalBlocksVertical.Count; i++)
            {
                identicalBlocksHorizontalAndVertical.Add(identicalBlocksVertical[i]);
            }
        }
    }

    void DeleteBlocks()
    {
        int points = 0;
        if (blocksCollectedLine.Count == 16 && identicalBlocksHorizontalAndVertical.Count >= 3)
        {
            for (int i = 0; i < blocksCollectedLine.Count; i++)
            {
                blocksDelete.Add(blocksCollectedLine[i]);
            }
            points += _pointsCollectedLine;
            for (int i = 0; i < identicalBlocksHorizontalAndVertical.Count; i++)
            {
                blocksDelete.Add(identicalBlocksHorizontalAndVertical[i]);
                points += _pointsIdenticalBlocks;
            }
        }
        else if (blocksCollectedLine.Count == 16)
        {
            for (int i = 0; i < blocksCollectedLine.Count; i++)
            {
                blocksDelete.Add(blocksCollectedLine[i]);
            }
            points += _pointsCollectedLine;
        }
        else if (identicalBlocksHorizontalAndVertical.Count >= 3)
        {
            for (int i = 0; i < identicalBlocksHorizontalAndVertical.Count; i++)
            {
                blocksDelete.Add(identicalBlocksHorizontalAndVertical[i]);
                points += _pointsIdenticalBlocks;
            }
        }
        if (points != 0)
        { 
            score.AddPoints(points);
            for (int k = 0; k < blocksDelete.Count; k++)
            {
                if (blocksDelete[k] != null || blocksDelete[k] == null)
                {
                    blocksDelete[k]._isDelete = true;
                    blocksDelete[k].BlockAnim();
                    blocksDelete[k].sr.enabled = false;
                    Destroy(blocksDelete[k].gameObject, 1f);
                }
            }
        }
    }
    private void BlockAnim()
    {
        GameObject go = Instantiate(prefab, transform.position, Quaternion.identity);
        go.GetComponent<SpriteRenderer>().sprite = sr.sprite;
    }
}
