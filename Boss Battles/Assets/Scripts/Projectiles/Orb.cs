using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : BossBase
{
    private bool canMove = false;
    protected override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
        StartCoroutine(DelayedMovement(5f));
        Debug.Log("They are moving");

    }
    protected virtual void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
    }  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            base.DamagePlayer();
        }
    }
    private IEnumerator DelayedMovement(float delay)
    {
        yield return new WaitForSeconds(delay);

        canMove = true;
    }
}
