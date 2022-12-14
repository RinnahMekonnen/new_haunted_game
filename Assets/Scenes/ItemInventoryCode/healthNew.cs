using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthNew : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
 
    public int damage = 1;
    public int healing = 1;
    private bool dead;
    public GameObject[] hearts;
    public GameObject heart;
    
    
    private void Start()
    {
        currentHealth = hearts.Length;
    }
 
 
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.P))
        {
            ApplyHealing();
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            DamageHealth();
        }
        
        
    }
 
    void ApplyHealing()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = currentHealth + healing;
            Instantiate(hearts[currentHealth-2] = heart);
        }
    }
 
    public void DamageHealth()
    {
        if (currentHealth > 0)
        {
            currentHealth = currentHealth - damage;
            Destroy(hearts[currentHealth].gameObject);
        }
        else dead = true;
    }
}


