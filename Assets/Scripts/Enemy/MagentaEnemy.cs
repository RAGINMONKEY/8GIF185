using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagentaEnemy : MonoBehaviour
{
    public int maxHealth;
    public HealthBar healthBar;
    public float timeToTag;
    public List<string> tagList;
    public GameObject bloodParticles;
    public AudioClip hurtSound;
    

    private int currentHealth;
    private float timer;
    


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        tagList.Clear();
        timer = 0f;
    }

    private void Update()
    {
        if(tagList.Count > 0)
        { 
            timer += Time.deltaTime;

            if(timer > timeToTag)
            {
                timer = 0f;
                tagList.Clear();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (isHit(collision.gameObject.tag))
        {
            tagList.Add(collision.gameObject.tag);

            if (tagList.Contains("Red") && tagList.Contains("Blue"))
            {
                currentHealth--;
                healthBar.SetHealth(currentHealth);
                GameObject bloodEffect = (GameObject)Instantiate(bloodParticles, collision.transform.position, collision.transform.rotation);
                Destroy(bloodEffect, 5f);
                AudioSource.PlayClipAtPoint(hurtSound, collision.transform.position);

                if (currentHealth <= 0)
                    Destroy(this.gameObject);
            }
        }
    }

    // Use by the enemy when he take a damage
    public bool isHit(string projectileTag)
    {
        if (projectileTag == "Blue" || projectileTag == "Red")   
        return true;
        else return false;
    }

   
}