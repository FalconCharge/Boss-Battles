using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public LayerMask groundLayer;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(rb == null)
        {
            Debug.LogError("No rigibody connected to player.");
        }
    }
    private void Update()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        movePlayer();

        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    //Performs the movement of the player
    private void movePlayer()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) )
        {
            Jump();
        }
    }
    //Points a raycast down from the player position and if It touches ground returns true else false
    public bool GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        return hit.collider != null;
    }
    //Performs player Jump
    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
