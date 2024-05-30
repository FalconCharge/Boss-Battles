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

    [SerializeField] private Animator animbody;

    private Rigidbody2D rb;
    private bool isGrounded;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        MovePlayer();
        
        
    }
    private void MovePlayer()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        if (moveX < 0)
        {
            animbody.SetFloat("Speed", -moveX);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (moveX > 0)
        {
            animbody.SetFloat("Speed", moveX);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else { animbody.SetFloat("Speed", moveX); }

        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        isGrounded = GroundCheck();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animbody.SetBool("isJumping", true);
            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
    }
    private bool GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.815f, groundLayer);

        return hit.collider != null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            animbody.SetBool("isJumping", false);
        }
    }
}
