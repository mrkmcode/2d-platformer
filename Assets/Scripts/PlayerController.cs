﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;   
    public float moveSpeed;
    public float jumpForce;
    public float bounceForce;
    public Rigidbody2D theRB;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool isGrounded;
    private bool canDoubleJump;

    private Animator anim;
    private SpriteRenderer theSR;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {   
        if(knockBackCounter <= 0)
        {
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        
            if(isGrounded) {
                canDoubleJump = true;
            } 


            if (Input.GetButtonDown("Jump")) {

                if (isGrounded) {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    AudioManager.instance.playSFX(10);
                } else {
                    if (canDoubleJump) {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        canDoubleJump = false;
                        AudioManager.instance.playSFX(10);
                    }
                }
            }

            if (theRB.velocity.x < 0) {
                theSR.flipX = true;
            } else if (theRB.velocity.x > 0) {
                theSR.flipX = false;
            }

            anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
            anim.SetBool("isGrounded", isGrounded);
        }
        else
        {
            knockBackCounter -= Time.deltaTime;

            if(!theSR.flipX) {
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
            } else {
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
            }
        }     
        
    }

    public void knockBack()
    {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f, knockBackForce);
    
        anim.SetTrigger("hurt");
    }

    public void bounce()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
        AudioManager.instance.playSFX(10);
    }
}
