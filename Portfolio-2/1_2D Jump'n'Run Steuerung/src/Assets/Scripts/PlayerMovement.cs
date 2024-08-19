using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public float moveSpeed = 11f;
    public float jumpForce = 14f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundRadius = 0.2f;
    private bool isGrounded;
    private float moveX;
    private int jumpCount = 0;
    private int extraJumps = 1;

    private void Update()
    {
        CheckIfGrounded();

        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < extraJumps))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        Move();
        FlipSprite();
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        if (isGrounded)
        {
            jumpCount = 0;
        }
    }

    private void Move()
    {
        rigidBody.velocity = new Vector2(moveX * moveSpeed, rigidBody.velocity.y);
    }

    private void Jump()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        jumpCount++;
    }

    private void FlipSprite()
    {
        if (moveX != 0)
        {
            spriteRenderer.flipX = moveX < 0;
        }
    }
}
