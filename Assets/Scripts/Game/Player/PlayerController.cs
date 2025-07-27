using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Rigidbody2D rb;
    private Animator anim;

    public float speedMove;
    public float force;

    public bool isGround, isDoubleJump;
    private int direction;

    private enum State { idle,run,jump}
    private State state = State.idle;

    public AudioSource jump;
    public AudioSource item;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Rotate();
        ChangeAnimation();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Rotate()
    {
        if (direction > 0)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        if (direction < 0)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
    }
    void Move()
    {
        Vector2 moveMent = new Vector2(direction, rb.linearVelocity.y);
        if (moveMent != Vector2.zero)
        {
            rb.linearVelocity = new Vector2(moveMent.x * speedMove, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }
    void ChangeAnimation()
    {
        anim.SetInteger("state", (int)state);

        if (isGround)
        {
            if (direction != 0)
            {
                state = State.run;
            }
            else
            {
                state = State.idle;
            }
        }
        else
        {
            state = State.jump;
        }       
    }
    void Jump()
    {
        if (!isDoubleJump)
        {
            if (isGround)
            {
                jump.Play();
                isDoubleJump = true;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                isGround = false;
            }
        }
        else
        {
            jump.Play();
            isDoubleJump = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
    public void Spring()
    {
        isDoubleJump = false;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * 2 * force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("obstacle"))
        {
            MenuManager.instance.GameFail();
        }
    }
    #region PlayerInput

    public void MoveLeft()
    {
        direction = -1;
    }
    public void MoveRight()
    {
        direction = 1;
    }
    public void ExitMove()
    {
        direction = 0;
    }
    public void ButtonJump()
    {
        Jump();
    }
    #endregion

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isGround = true;
            isDoubleJump = false;
        }

        if(collision.gameObject.CompareTag("door"))
        {
            MenuManager.instance.GameSuccess();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGround = false;
        }
    }
}
