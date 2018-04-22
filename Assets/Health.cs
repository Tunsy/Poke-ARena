using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int currentHealth;
    public int maxHealth;
    public bool isAlive;
    public HealthBarStatus healthBar;

    public void Start()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }
    
    public void Death()
    {
        isAlive = false;
        GameManager.instance.EndGame();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0) {
            currentHealth = 0;
            Death();
        }
        healthBar.UpdateSize();
    }
}
