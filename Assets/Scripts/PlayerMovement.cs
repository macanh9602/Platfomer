﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float runSpeed = 10f;
    [SerializeField] public float jumpSpeed = 5f;
    [SerializeField] public float climbSpeed = 10f;
    Vector2 moveInput;
    Rigidbody2D myrigidbody2D;
    Animator myAnimator;
    CapsuleCollider2D  myBodycollider2D;
    float gravityStart;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodycollider2D = GetComponent<CapsuleCollider2D>();
        gravityStart = myrigidbody2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        flipFace();
        climbingLadder();
        myAnimator.SetFloat("yVelocity", myrigidbody2D.velocity.y);
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {
        if(value.isPressed && myBodycollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            
            myrigidbody2D.velocity += new  Vector2(0f, jumpSpeed);
           
                myAnimator.SetBool("Jump", true);  
            
        }      
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            myAnimator.SetBool("Jump", false);
        }
    }

    void Run()
    {
        bool IsHorizontalMoving = Mathf.Abs(myrigidbody2D.velocity.x) > 0;
        Vector2 myvelocity = new Vector2(moveInput.x * runSpeed, myrigidbody2D.velocity.y);
        myrigidbody2D.velocity = myvelocity;
        myAnimator.SetBool("IsRunning", IsHorizontalMoving);
    }
    void flipFace()
    {
        bool IsHorizontalMoving = Mathf.Abs(myrigidbody2D.velocity.x) > 0;
        if (IsHorizontalMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(myrigidbody2D.velocity.x), transform.localScale.y);
        }
        
    }
    void climbingLadder()
    {

        if (myBodycollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            Vector2 myvelocity = new Vector2(myrigidbody2D.velocity.x, moveInput.y * climbSpeed);
            myrigidbody2D.velocity = myvelocity;
            myrigidbody2D.gravityScale = 0;
        }
        else myrigidbody2D.gravityScale = gravityStart;
        
    }
}
