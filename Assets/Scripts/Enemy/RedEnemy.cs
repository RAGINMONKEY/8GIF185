using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    public int maxHealth;
    public HealthBar healthBar;

    private int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (isHit(collision.gameObject.tag))
        {
            currentHealth--;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
                Destroy(this.gameObject);
        }
    }

    // Use by the enemy when he take a damage
    public bool isHit(string projectileTag)
    {
        if (projectileTag == "Red")
            return true;
        else return false;
    }
}