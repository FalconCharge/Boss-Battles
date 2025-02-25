using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossBase : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float maxHealth = 100;
    [SerializeField] protected float damage = 20f;
 
    protected float currentHealth;
    protected GameObject player;
    protected GameObject healthBar;
    protected Rigidbody2D rb;
    
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        healthBar = GameObject.FindGameObjectWithTag("BossHealth");

        healthBar.GetComponent<HealthBar>().SetMaxHealth(maxHealth);
        
        rb = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            Debug.LogError("Player GameObject not found! Make sure it is tagged as 'Player'.");
        }else if(healthBar == null){
            Debug.LogError("HealthBar GameObject not found! Make sure it is tagged as 'BossHealth'.");
        }
        else if(rb == null)
        {
            Debug.LogError("RigiBody Not found on GameObject! Make sure to add it");
        }
        currentHealth = maxHealth;
    }
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.GetComponent<HealthBar>().SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            LoadNext();
            Die();
        } 
    }
    protected virtual void Die()
    {
        
        Destroy(gameObject);
    }
    protected virtual void DamagePlayer()
    {
        player.GetComponent<Player>().TakeDamage(damage);
    }
    protected virtual void LoadNext()
    {
        FindObjectOfType<GameManager>().NextBoss();
    }
}

