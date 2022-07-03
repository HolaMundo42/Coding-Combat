using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_script : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;

    [SerializeField] int jumpStr;
    [SerializeField] float jumpCounterT;

    [SerializeField] float dashRecoil;
    [SerializeField] float dashStr = 3;

    double offset = 0;
    string prefix;

    public int dir;
    double moveInput;
    float jumpCounter = 3;

    bool canDash = true;
    public bool isDashing = false;
    bool isGrounded;
    public bool isJumping = false;
    bool facingRight = true;

    [SerializeField] Transform feetPos;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;


    void Start()
    {
        getPlayerNum();
        rb = GetComponent<Rigidbody2D>();
    }

    void getPlayerNum()
    {
        if (gameObject.GetComponent<PlayerStats>().playerNum == 1)
        {
            prefix = "p1";
        }
        else if (gameObject.GetComponent<PlayerStats>().playerNum == 2)
        {
            prefix = "p2";
        }
        else
        {
            Debug.Log("u lpm");
        }
    }

    void Update()
    {


        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (Time.time - offset > dashRecoil)
        {
            canDash = true;
        }
        if (Time.time - offset > 0.35)
        {
            isDashing = false;
        }

        if (moveInput > 0)
        {
            Move(1);
        }

        else if (moveInput < 0)
        {
            Move(-1);
        }

        if (transform.position.y < -8)
        {
            transform.position = new Vector2(-8, 0.5f);
        }
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw(prefix + "Horizontal");
        
        if (Input.GetAxisRaw(prefix+"Dash") > 0 && canDash)
        {
            Dash();
        }

        if (Input.GetButton(prefix + "Jump") && isGrounded)
        {
            Jump();
        }
        else if (Input.GetButton(prefix + "Jump") && isJumping)
        {
            Jump2();
        }

        if (Input.GetButtonUp(prefix + "Jump"))
        {
            isJumping = false;
        }
    }

    void Move(int dirx)
    {
        if (isDashing) { return; }

        if (dirx > 0 && !facingRight)
        {
            Flip();
        }
        else if (dirx < 0 && facingRight)
        {
            Flip();
        }

        dir = dirx;
        rb.velocity = new Vector2(dir * speed, rb.velocity.y);
    }
    void Dash()
    {
        rb.velocity = new Vector2(dir * dashStr, rb.velocity.y);
        offset = Time.time;
        isDashing = true;
        canDash = false;
    }

    void Jump()
    {
        if (isDashing) { return; }
        rb.velocity = Vector2.up * jumpStr;
        jumpCounter = jumpCounterT;
        isJumping = true;
    }
    void Jump2()
    {
        if (jumpCounter > 0)
        {
            if (isDashing) { return; }
            rb.velocity = Vector2.up * jumpStr;
            jumpCounter -= Time.deltaTime;
        }
        else
        {
            isJumping = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}