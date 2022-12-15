using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    //public Slider healthSlider;
    public bool dead = false;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            health = 0;
            //Die
            dead = true;
            anim.SetTrigger("Dead");
           // healthSlider.gameObject.SetActive(false);
        }
        else
        {
            anim.SetTrigger("Hit");
        }

        //healthSlider.value = health;
        //Update Slider UI
    }
}
