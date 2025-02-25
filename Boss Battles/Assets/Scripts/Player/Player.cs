using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
   
    public float timeBTWAttacks = 0.5f;
    private float startTimeBTWAttacks; 



    


    //For Animation + Sound
    [SerializeField] private Animator playeranim;
    [SerializeField] private Animator weaponanim;
    [SerializeField] private AudioSource swing;
    [SerializeField] private GameObject death;

    public HealthBar healthBar;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (Time.time >= startTimeBTWAttacks + timeBTWAttacks)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                 
                weaponanim.SetTrigger("Attack");
                swing.Play();
                startTimeBTWAttacks = Time.time;
            }
        }
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        playeranim.SetTrigger("DamageTaken");
       

        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Instantiate(death, transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().GameOver();
            
            Destroy(gameObject);
        }

    }
    
}