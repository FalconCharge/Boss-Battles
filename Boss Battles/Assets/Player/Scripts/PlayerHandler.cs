using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{

    public float currHealth;
    public float maxHealth;

    [SerializeField] GameObject healthBar;
    private void Start()
    {
        healthBar.GetComponent<Slider>().maxValue = maxHealth;
        currHealth = maxHealth;
    }
    private void Update()
    {
        UpdateHealthBar();
        TakeDamage(0.001f);
    }

    public void TakeDamage(float damage)
    { 
        currHealth -= damage;

        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void UpdateHealthBar()
    {
        healthBar.GetComponent<Slider>().value = currHealth;

    }
    
}
