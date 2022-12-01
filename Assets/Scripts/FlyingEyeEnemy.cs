using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeEnemy : MonoBehaviour
{
    public bool attackStake = false;
    public float attackRadius = 2f;
    public float speed = 2f;
    public float attackDelay = 1f;
    public int damage = 10;

    float time;
    Vector3 originalPosition;
    PlayerHealth playerInRange;
    Animator anim;
    EnemyHealth enemyHealth;
    bool facingRight = true;

    private void Awake()
    {
        originalPosition = transform.position;
        time = attackDelay;

        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (enemyHealth.dead) return;

        int playercount = 0;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.CompareTag("Player"))
            {
                playercount++;
                playerInRange = colliders[i].GetComponent<PlayerHealth>();
            }
        }

        if (playercount <= 0)
            playerInRange = null;

        if(playerInRange != null)
        {
            if (!playerInRange.dead)
            {
                float distance = Vector3.Distance(transform.position, playerInRange.transform.position);
                if (distance <= 1.8f)
                {
                    //Attack
                    time += Time.deltaTime;
                    if (time >= attackDelay)
                    {
                        time = 0f;
                        Attack();
                    }
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, playerInRange.transform.position, speed);
                }

                float xDist = playerInRange.transform.position.x - transform.position.x;
                if(xDist < 0)
                {
                    if (facingRight)
                    {
                        facingRight = false;
                        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    }
                }
                else if(xDist > 0)
                {
                    if (!facingRight)
                    {
                        facingRight = true;
                        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    }
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, originalPosition, speed);

                if (!facingRight)
                {
                    facingRight = true;
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, speed);

            if (!facingRight)
            {
                facingRight = true;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    public void Attack()
    {
        if(playerInRange != null)
        {
            playerInRange.TakeDamage(damage);
            //Damage Player

            anim.SetTrigger("Attack");
            //Show Attack Animation
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
