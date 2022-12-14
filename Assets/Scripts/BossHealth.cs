using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public float health = 10;

    public bool isInvulnerable = false;

    public Animator animator;

    public bool isdead;

    public float destroyOffsetTime = 1.8f;

    public void Update()
    {
        if (isdead)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5)
            {
                Destroy(gameObject, destroyOffsetTime);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (isInvulnerable)
        {
            return;
        }

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("Die");
        isdead = true;
    }
}
