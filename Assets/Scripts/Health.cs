using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int currentHealth;
    public int maxHealth;
    public bool isAlive;
    public bool isInvicible;
    public float invincibilityTimer;
    public HealthBarStatus healthBar;
    public AudioClip hurtSound;
    private SkinnedMeshRenderer renderer;


    public void Start()
    {
        currentHealth = maxHealth;
        isAlive = true;
        isInvicible = false;
        renderer = GetComponent<SkinnedMeshRenderer>();
    }
    
    public void Death()
    {
        isAlive = false;
        GameManager.instance.EndGame();
    }

    public IEnumerator Invincible(float waitTime)
    {
        var endTime = Time.time + waitTime;
        while (Time.time < endTime)
        {
            renderer.enabled = false;
            yield return new WaitForSeconds(0.07f);
            renderer.enabled = true;
            yield return new WaitForSeconds(0.07f);
        }
        isInvicible = false;
    }

    public void TakeDamage(int damageAmount)
    {
        if(isInvicible == false) { 
            currentHealth -= damageAmount;
            isInvicible = true;
            StartCoroutine("Invincible", invincibilityTimer);
            SoundManager.instance.PlaySingle(hurtSound);
            if (currentHealth <= 0) {
                currentHealth = 0;
                Death();
            }
            healthBar.UpdateSize();
        }
    }
}
