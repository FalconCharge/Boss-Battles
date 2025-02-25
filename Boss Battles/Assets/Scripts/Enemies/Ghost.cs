using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BossBase
{
    
    protected override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        float moveDirection = (transform.rotation.y < 0) ? 1 : -1;

        rb.velocity = new Vector2 (moveDirection * moveSpeed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            base.DamagePlayer();
        }
    }
}
