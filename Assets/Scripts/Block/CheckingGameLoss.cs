using UnityEngine;

public class CheckingGameLoss : MonoBehaviour
{
    [SerializeField] private UILogicsGame uILogicsGame;

    [SerializeField] float distansRay;
    [SerializeField] float y;

    private void Start()
    {
        y = transform.position.y;
    }

    internal void ActiveRay()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position + new Vector3(0.5f, 0, 0), transform.right, distansRay);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.CompareTag("Block"))
            {
                var block = hits[i].collider.GetComponent<Block>();
                if (block.transform.position.y == y && block.isFall == false)
                {
                    uILogicsGame.LossGamePanel();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + new Vector3(0.5f, 0, 0), transform.right + new Vector3(distansRay, 0, 0), Color.red);
    }
}
