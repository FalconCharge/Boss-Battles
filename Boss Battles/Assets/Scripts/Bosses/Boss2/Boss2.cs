using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Boss2 : BossBase
{
    [SerializeField] private float tooFar;
    [SerializeField] private float tooClose;
    [SerializeField] private float height;
    [SerializeField] private float initalMaxX;
    [SerializeField] private float initalMinX;

    [SerializeField] private float currentMaxX;
    [SerializeField] private float currentMinX;

    [SerializeField] private float diveDepth;

    private bool isLow = false;
    public List<GameObject> enemies;
    public List<GameObject> spawnPoints;

    private Vector2 movedir;
    private float maxSpeed = 30f;
    protected override void Start()
    {
        base.Start();
        transform.position = new Vector3(0, height, 0);
    }

    private void Update()
    {
        if(player != null)
        {
            moveSpeed = Mathf.Lerp(maxSpeed, 5f, currentHealth / maxHealth);
        }
    }
    private void FixedUpdate()
    {
        
        if(player != null)
        {
            MoveLeftRight();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void MoveTowardsPlayer()
    {
        
        Vector3 direction = player.transform.position - transform.position;
        float distanceToPlayer = direction.magnitude;

       
        if (direction.x > 0f) { transform.localRotation = Quaternion.Euler(0f, 180f, 0f); }
        else if (direction.x < 0f) { transform.localRotation = Quaternion.Euler(0f, 0f, 0f); }

        Vector3 newPosition = transform.position;

        newPosition.y = Mathf.Max(newPosition.y, height);
        
        if (distanceToPlayer < tooClose)
        {
            newPosition -= direction.normalized * moveSpeed * Time.deltaTime;
        }
        else if(distanceToPlayer > tooFar)
        {
            newPosition += direction.normalized * moveSpeed * Time.deltaTime;
        }
        transform.position = newPosition;
    }
    private void MoveLeftRight()
    {
        int rand = Random.Range(0, 4);
        if (movedir == Vector2.zero){movedir = Vector2.left;}

        else if (transform.position.x >= currentMaxX)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            movedir = Vector2.left;
            

            if(rand == 2) {currentMaxX = 12f;}

            if(transform.position.x >= 12f)
            {
                transform.position = new Vector3(transform.position.x, diveDepth, 0f);
                isLow = true;
                currentMinX = -12f;
                
            }
        }
        else if (transform.position.x <= currentMinX)
        {
            if (isLow)
            {
                transform.position = new Vector3(transform.position.x, height, 0f);
                isLow = false;
                currentMinX = initalMinX;
                currentMaxX = initalMaxX;
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                movedir = Vector2.right;
                
            }
        }
        rb.velocity = movedir * moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            base.DamagePlayer();
        }
        
    }


}
