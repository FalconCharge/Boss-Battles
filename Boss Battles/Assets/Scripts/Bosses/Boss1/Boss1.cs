using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : BossBase
{
    [SerializeField] private float attackDistance = 1.5f;
    [SerializeField] private float startTimeBTWAttack = 1f;

    //Attack2
    [SerializeField] private float startTimeBTWAttack2 = 10f;
    [SerializeField] private float attackDistance2 = 10f;
    private float timeBTWAttack2;
    [SerializeField] private GameObject orbs;

    private float timeBTWAttack;
    private bool isMoving = false;

    private void Update()
    {
        if(player != null)
        {
            Attack();
            Attack2();
        }
    }
    private void FixedUpdate()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }
    private void MoveTowardsPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0f;
        direction.Normalize();

        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;

            rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);


            if (direction.x > 0f) { transform.localRotation = Quaternion.Euler(0f, 180f, 0f); }
            else if (direction.x < 0f) { transform.localRotation = Quaternion.Euler(0f, 0f, 0f); }
        }
    }
    //changing the attack to instantiate static balls around it to shoot out! which happens every 10 seconds
    private void Attack()
    {

        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            if (!isMoving)
            {
                timeBTWAttack += Time.deltaTime;

                if (timeBTWAttack >= startTimeBTWAttack)
                {
                    timeBTWAttack = 0f;
                    player.GetComponent<Player>().TakeDamage(damage);
                }
            }
            
        }
    }
    private void Attack2()
    {
        timeBTWAttack2 += Time.deltaTime;
        
        if(timeBTWAttack2 >= startTimeBTWAttack2)
        {
            timeBTWAttack2 = 0f;

            if (Vector3.Distance(transform.position, player.transform.position) >= attackDistance2)
            {
                timeBTWAttack2 = 0f;

                // Start power-up animation

                // Stop the boss from moving
                isMoving = false;

                // Instantiate 4 orbs around the boss
                Instantiate(orbs, transform.position + transform.right, transform.rotation);
                Instantiate(orbs, transform.position + -transform.right, transform.rotation);
                Instantiate(orbs, transform.position + transform.up, transform.rotation);
                Instantiate(orbs, transform.position + -transform.up, transform.rotation);

                // Rotate the spawnpoints so the orbs will go forward

                // Add camera shake on power-up and shot
            }
        }
    }
}

