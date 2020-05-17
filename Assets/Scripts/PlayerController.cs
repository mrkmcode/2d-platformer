﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D theRB;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if (Input.GetButtonDown("Jump")) {

            if (isGrounded) {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
        
        }
    }
}
