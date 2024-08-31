using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private PlayerInput playerInput;
    public bool facingRight = true;

    private Rigidbody2D rb;

    private int extraJump;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;
    //public AudioManager audioManager;


    private void Awake()
    {
        facingRight = true;
        playerInput = GetComponent<PlayerInput>();
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log(facingRight);
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.909838f, 0.016975f), CapsuleDirection2D.Horizontal, 0, WhatIsGround);
        if (playerInput.Move > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (playerInput.Move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
           
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            extraJump = 1;
        }
        rb.velocity = new Vector2(playerInput.Move * speed, rb.velocity.y);
    }

    public void jump()
    {
        if ( (extraJump > 0 || isGrounded))
        {
            //audioManager.PlaySFX(audioManager.jump);
            rb.velocity = new Vector2(rb.velocity.x,JumpForce);
            if (!isGrounded)
            {
                extraJump--;
            }
        }
    }



}
