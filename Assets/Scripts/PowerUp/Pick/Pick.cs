using UnityEngine;

public class Pick : MonoBehaviour
{
    GameManager gameManager;
    UILogicTopBar uILogicTopBar;
    UILogicsGame uILogicsGame;
    //DatabaseManager databaseManager;


    [SerializeField] private GameObject particleAddPick;
    [SerializeField] private GameObject buttonAddPick;
    [SerializeField] private GameObject particlePickRight;
    [SerializeField] private GameObject particlePickLeft;
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        gameManager = FindObjectOfType<GameManager>();       
        uILogicTopBar = FindObjectOfType<UILogicTopBar>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
        //databaseManager = FindObjectOfType<DatabaseManager>();
    }
    public void PickActive()
    {
        FoundBlock();
    }
    public void FoundBlock()
    {
        if (gameManager._playerPick >= 1)
        {
            Movement movement = FindObjectOfType<Movement>();
            RaycastHit2D[] hitRight = Physics2D.RaycastAll(movement.transform.position + new Vector3(0.34f, -0.15f, 0), transform.right, 0.22f);
            if (hitRight.Length > 1)
            {
                for (int i = 0; i < hitRight.Length; i++)
                {
                    if (hitRight[i].collider.CompareTag("Block"))
                    {
                        Block block = hitRight[i].collider.GetComponent<Block>();
                        if(block._isDelete)
                        {
                            break;
                        }
                        else
                        {
                            block._isDelete = true;
                            block._isMove = false;
                            GameObject go = Instantiate(particlePickRight, transform.position = new Vector3(block.transform.position.x + 1f,
                                                                                                               block.transform.position.y + 0.5f,
                                                                                                               block.transform.position.z),
                                                                                                               Quaternion.identity);
                            go.transform.parent = block.transform;
                            Destroy(hitRight[i].collider.gameObject, 0.6f);
                            UsePick();
                            uILogicsGame.TextGameAmountOfPick();
                            break;
                        }
                    }
                }
            }
            else
            {
                RaycastHit2D[] hitLeft = Physics2D.RaycastAll(movement.transform.position - new Vector3(0.34f, 0.15f, 0), -transform.right, 0.22f);
                if (hitLeft.Length > 1)
                {
                    for (int i = 0; i < hitLeft.Length; i++)
                    {
                        if (hitLeft[i].collider.CompareTag("Block"))
                        {
                            Block block = hitLeft[i].collider.GetComponent<Block>();
                            if (block._isDelete)
                            {
                                break;
                            }
                            else
                            {
                                block._isDelete = true;
                                block._isMove = false;
                                GameObject go = Instantiate(particlePickLeft, transform.position = new Vector3(block.transform.position.x - 1f,
                                                                                                                   block.transform.position.y + 0.5f,
                                                                                                                   block.transform.position.z),
                                                                                                                   Quaternion.identity);
                                go.transform.parent = block.transform;
                                Destroy(hitLeft[i].collider.gameObject, 0.6f);
                                UsePick();
                                uILogicsGame.TextGameAmountOfPick();
                                break;
                            }
                        }
                    }
                }
            }
        }      
    }
    public void UsePick()
    {
        gameManager._playerPick--;
        uILogicTopBar.TextPickTopBarPanel();
        gameManager.SavePlayerPrefsPick();

        //databaseManager.SaveStatsDB();

    }
    public void AddPick()
    {
        gameManager._playerPick++;
        Instantiate(particleAddPick, buttonAddPick.transform.position, Quaternion.identity);
        gameManager.SavePlayerPrefsPick();

        //databaseManager.SaveStatsDB();

    }
}
