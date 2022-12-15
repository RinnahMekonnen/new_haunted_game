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
    private healthScript _healthScript;
    Animator anim;
    EnemyHealth enemyHealth;
    bool facingRight = true;

    private void Awake()
    {
        originalPosition = transform.position;
        time = attackDelay;
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        _healthScript = GetComponent<healthScript>();
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
               _healthScript = colliders[i].GetComponent<healthScript>();
            }
        }

        if (playercount <= 0)
            _healthScript = null;

        if(_healthScript != null)
        {
            if (_healthScript.PlayerHealth>0)
            {
                float distance = Vector3.Distance(transform.position, _healthScript.transform.position);
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
                    transform.position = Vector3.Lerp(transform.position, _healthScript.transform.position, speed);
                }

                float xDist = _healthScript.transform.position.x - transform.position.x;
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
        if(_healthScript != null)
        {
            _healthScript.TakeDamage(1);
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
