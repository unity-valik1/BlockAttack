using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    [SerializeField] private Collider2D handsPlayer;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _movement;

    [SerializeField] private bool _isJump;

    void Awake()
    {
        Init();
    }
    private void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Jump()
    {
        //комп
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) == 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
            //rb.AddForce(Vector2.up * _jumpForce);
        }

        //тел
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
        //комп
        _movement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))
        {
            sr.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            sr.flipX = true;
        }

        //тел
        rb.velocity = new Vector2(_movement * _speed, rb.velocity.y);
    }

    //тел
    public void OnButtonJump()
    {
        _isJump = true;
    }
    public void OnButtonJumpUp()
    {
        _isJump = false;
    }
    public void OnButtonMoveLeft()
    {
        _movement = -1;
        animator.SetBool("MoveLeftArmor", true);
        animator.SetBool("MoveRightArmor", false);
        animator.SetBool("StandArmor", false);
        handsPlayer.enabled = true;
    }
    public void OnButtonMoveRight()
    {
        _movement = 1;
        animator.SetBool("MoveRightArmor", true);
        animator.SetBool("MoveLeftArmor", false);
        animator.SetBool("StandArmor", false);
        handsPlayer.enabled = true;
    }
    public void OnButtonMoveUp()
    {
        _movement = 0;
        animator.SetBool("StandArmor", true);
        animator.SetBool("MoveRightArmor", false);
        animator.SetBool("MoveLeftArmor", false);
        handsPlayer.enabled = false;
    }
}
