using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public Slider healthSlider;
    public bool dead = false;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            //Die
            dead = true;
            anim.SetTrigger("Die");
            healthSlider.gameObject.SetActive(false);
            Destroy(this.gameObject, 2f);
        }
        else
        {
            anim.SetTrigger("Hit");
        }

        healthSlider.value = health;
        //Update Slider UI
    }
}
