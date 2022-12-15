using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{
    public int PlayerHealth = 5;
    public bool invulnerable = false;
    public int iFrameTime = 2;
    SceneChanger sceneChanger;
    public float deathDelay = 3;

    public GameObject[] hearts;
    public GameObject heart;
    //public Text healthText;

    public void loadHealth(int health)
    {
        for (int i = 5-health; i > 0; i--)
        {
            hearts[i].SetActive(false);
            PlayerHealth = health;
        }
    }

    public void TakeDamage(int attackDamage)
    {
        Animator animator = GetComponent<Animator>();
        if (!invulnerable)
        {
           
            PlayerHealth -= attackDamage;
            hearts[PlayerHealth].SetActive(false);
            StartCoroutine(Invincible());
        }

        if (PlayerHealth <= 0)
        {
            PlayerHealth = 0;
            animator.SetTrigger("IsDead");
            //healthSlider.gameObject.SetActive(false);
            Destroy(this.gameObject, deathDelay);
            sceneChanger = GetComponent<SceneChanger>();
            sceneChanger.Scene1();
        }
    }
    
    public void addHeart()
    {
        if (PlayerHealth < 5)
        {
            hearts[PlayerHealth].SetActive(true);
            PlayerHealth += 1;
        }
    }

    IEnumerator Invincible()
    {
        invulnerable = true;
        yield return new WaitForSeconds(iFrameTime);
        invulnerable = false;
    }
}
