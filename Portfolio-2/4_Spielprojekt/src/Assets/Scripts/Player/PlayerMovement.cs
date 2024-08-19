using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public bool isMoving;

    private Animator animator; // Reference to the Animator component
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Initialize the Animator component
        spriteRenderer = GetComponent<SpriteRenderer>(); // Initialize the SpriteRenderer component
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;

        // Check if the character is moving
        isMoving = moveInput != Vector2.zero;

        // Update the Animator parameter with the isMoving boolean
        animator.SetBool("isMoving", isMoving);

        // Flip the sprite based on the mouse position relative to the player
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x < transform.position.x) // Mouse is on the left side
        {
            spriteRenderer.flipX = true;
        }
        else if (mousePosition.x > transform.position.x) // Mouse is on the right side
        {
            spriteRenderer.flipX = false;
        }
    }
}
