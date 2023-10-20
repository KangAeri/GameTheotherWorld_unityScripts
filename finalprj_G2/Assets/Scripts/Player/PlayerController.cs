using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float doulbJumpSpeed;

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D myFeet;
    private bool isGround;
    private bool canDoubleJump;

    public bool isSpeedDown = false;

    public bool isSpeedUp = false;


    public float speedDownSpeed = 0;

    public float speedUpSpeed = 0;


    public float timer = 0;

    internal void SpeedUp()
    {
        Debug.Log("speed up");
        isSpeedUp=true;
        timer=2;
    }





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();

    }

    internal void SpeedDown()
    {
        Debug.Log("speed down");
        isSpeedDown = true;
        timer = 2;

    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Run();
        Jump();
        CheckGrounded();
        SwitchAnimation();
        UpdateBuffTimer();
        //Attack();

    }

    private void UpdateBuffTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                if (isSpeedDown)
                {
                    isSpeedDown = false;
                }
                if (isSpeedUp)
                {
                    isSpeedUp = false;
                }
            }
        }
    }

    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
    void Flip()
    {
        bool plyerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (plyerHasXAxisSpeed)
        {
            if (rb.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (rb.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }

    }
    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");


        Vector2 playerVel = Vector2.zero;

        if (isSpeedDown)
        {
            playerVel = new Vector2(moveDir * speedDownSpeed, rb.velocity.y);
        }
        else if (isSpeedUp)
        {
            playerVel = new Vector2(moveDir * speedUpSpeed, rb.velocity.y);
        }
        else
        {
            playerVel = new Vector2(moveDir * runSpeed, rb.velocity.y);
        }


        rb.velocity = playerVel;
        bool plyerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("running", plyerHasXAxisSpeed);
        if (plyerHasXAxisSpeed)
        {
            SoundManager.Instance.PlayWalkSound();
        }
        else
        {
            SoundManager.Instance.StopWalkSound();
        }

    }
    void Jump()
    {

        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                anim.SetBool("jump", true);


                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);

                rb.velocity = Vector2.up * jumpVel;
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    anim.SetBool("doublejump", true);
                    Vector2 doubleJumpVel = new Vector2(0.0f, doulbJumpSpeed);
                    rb.velocity = Vector2.up * doubleJumpVel;
                    canDoubleJump = false;
                }
            }

        }
    }
    //void Attack()
    // {
    //if (Input.GetButtonDown("Attack"))
    //{
    //anim.SetTrigger("attack");
    // }
    // }
    void SwitchAnimation()
    {

        anim.SetBool("idle", false);
        if (anim.GetBool("jump"))
        {
            if (rb.velocity.y < 0.0f)
            {
                anim.SetBool("jump", false);
                anim.SetBool("fall", true);

            }
        }
        else if (isGround)
        {
            anim.SetBool("fall", false);
            anim.SetBool("idle", true);
        }
        if (anim.GetBool("doublejump"))
        {
            if (rb.velocity.y < 0.0f)
            {
                anim.SetBool("doublejump", false);
                anim.SetBool("doublefall", true);

            }
        }
        else if (isGround)
        {
            anim.SetBool("doublefall", false);
            anim.SetBool("idle", true);
        }
    }
}

