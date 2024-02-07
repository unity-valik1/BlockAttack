using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    ViewCupOnPlayer viewCupOnPlayer;


    [SerializeField] private Collider2D _handsPlayer;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    public float _movement;

    [SerializeField] private bool _isJump;

    void Awake()
    {
        Init();
    }
    private void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        viewCupOnPlayer = GetComponentInChildren<ViewCupOnPlayer>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Jump()
    {
        //����
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) == 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
            //rb.AddForce(Vector2.up * _jumpForce);
        }

        //���
        if (_isJump)
        {
            if (Mathf.Abs(rb.velocity.y) == 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
                //rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
    }
    void Move()
    {
        //����
        //_movement = Input.GetAxis("Horizontal");

        //���
        rb.velocity = new Vector2(_movement * _speed, rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_movement == -1)
        {
            PushLeft();
        }
        else if (_movement == 1)
        {
            PushRight();
        }
        else if(_movement == 0)
        {
            OnButtonMoveUp();
        }
    }
    private void OnTriggerExit2D(Collider2D handsPlayer)
    {
        if (_movement == -1)
        {
            PushNotLeft();
        }
        else if (_movement == 1)
        {
            PushNotRight();
        }
    }
    //���
    //������
    public void OnButtonJump()
    {
        _isJump = true;
    }
    public void OnButtonJumpUp()
    {
        _isJump = false;
    }
    //������ �����
    public void OnButtonMoveLeft()
    {
        _movement = -1;
        animator.SetBool("Idle", false);
        animator.SetBool("MoveLeft", true);
        animator.SetBool("MoveRight", false);
        animator.SetBool("PushRight", false);
        animator.SetBool("PushLeft", false);
        _handsPlayer.enabled = true;
        viewCupOnPlayer.ChangesCupLeft();
    }
    //������ ������
    public void OnButtonMoveRight()
    {
        _movement = 1;
        animator.SetBool("Idle", false);
        animator.SetBool("MoveRight", true);
        animator.SetBool("MoveLeft", false);
        animator.SetBool("PushRight", false);
        animator.SetBool("PushLeft", false);
        _handsPlayer.enabled = true;
        viewCupOnPlayer.ChangesCupRight();
    }
    //������
    public void OnButtonMoveUp()
    {
        _movement = 0;
        animator.SetBool("Idle", true);
        animator.SetBool("MoveRight", false);
        animator.SetBool("MoveLeft", false);
        animator.SetBool("PushRight", false);
        animator.SetBool("PushLeft", false);
        _handsPlayer.enabled = false;
        viewCupOnPlayer.ChangesCupFront();
    }

    //�������
    public void PushLeft()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("MoveLeft", false);
        animator.SetBool("MoveRight", false);
        animator.SetBool("PushRight", false);
        animator.SetBool("PushLeft", true);
        viewCupOnPlayer.ChangesCupLeft();
    }
    public void PushRight()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("MoveLeft", false);
        animator.SetBool("MoveRight", false);
        animator.SetBool("PushRight", true);
        animator.SetBool("PushLeft", false);
        viewCupOnPlayer.ChangesCupRight();
    }

    //�� �������� � �������� � �������
    public void PushNotLeft()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("MoveRight", false);
        animator.SetBool("MoveLeft", true);
        animator.SetBool("PushRight", false);
        animator.SetBool("PushLeft", false);
        viewCupOnPlayer.ChangesCupLeft();
    }
    public void PushNotRight()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("MoveRight", true);
        animator.SetBool("MoveLeft", false);
        animator.SetBool("PushRight", false);
        animator.SetBool("PushLeft", false);
        viewCupOnPlayer.ChangesCupRight();
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position - new Vector3(0.34f, 0.15f, 0), -transform.right + new Vector3(0.78f, 0, 0), Color.red);//�����
        Debug.DrawRay(transform.position + new Vector3(0.34f, -0.15f, 0), transform.right - new Vector3(0.78f, 0, 0), Color.red);//������
    }
}
