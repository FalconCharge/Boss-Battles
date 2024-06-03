using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animbody;

    // Start is called before the first frame update
    void Start()
    {
        animbody = GetComponent<Animator>();

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
        float moveY = Input.GetAxisRaw("Vertical");
        bool isGrounded = GetComponent<PlayerMovement>().GroundCheck();

        animbody.SetFloat("Speed", Mathf.Abs(moveX));

        if(moveY > 0f)
        {
            animbody.SetBool("IsJumping", !isGrounded); //In air
        }
        else
        {
            animbody.SetBool("IsJumping", isGrounded); //On Ground
        }


        if (moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Facing left
        }
        else if (moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Facing right
        }
    }
    public void DamageTaken()
    {
        animbody.SetTrigger("TakeDamage");
    }
}
