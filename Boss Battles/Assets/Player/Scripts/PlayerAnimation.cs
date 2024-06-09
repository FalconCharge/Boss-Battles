using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animbody;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animbody = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (animbody == null)
        {
            Debug.LogError("Animator component not found on the player.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(animbody != null)
        {
            HandleAnimations();
        }
    }
    private void HandleAnimations()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY;
        

        animbody.SetFloat("Speed", Mathf.Abs(moveX));
        moveY = Mathf.Abs(rb.velocity.y);

        if(GetJump() || GetJumpFalling())
        {
            animbody.SetBool("IsJumping", true);
        }
        else
        {
            animbody.SetBool("IsJumping", false);
        }

        
    }
    private bool GetJump()
    {
        return GetComponent<PlayerMovement>().IsJumping;
    }
    private bool GetJumpFalling()
    {
        return GetComponent<PlayerMovement>().IsJumpFalling;
    }
}
