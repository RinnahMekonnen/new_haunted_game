using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPlayerMovement : MonoBehaviour
{
    public float speed = 20;
    public float stopSmoothness = 0.3f;
    public bool isFacingRight = true;
    public float attackDelay = 1f;
    public float attackRadius = 2f;
    public int damage = 30;

    float horizontal;
    float time;
    bool attackReset = false;

    Rigidbody2D rb;
    Animator anim;
    PlayerHealth playerHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (playerHealth.dead) return;

        horizontal = Input.GetAxisRaw("Horizontal");

        //Sprite Flipping
        if(horizontal < 0)
        {
            if (isFacingRight)
            {
                isFacingRight = false;
                transform.localScale = new Vector3(transform.localScale.x * -1
                    , transform.localScale.y, transform.localScale.z);
                playerHealth.healthSlider.transform.localScale = new Vector3(playerHealth.healthSlider.transform.localScale.x * -1
                    , playerHealth.healthSlider.transform.localScale.y, playerHealth.healthSlider.transform.localScale.z);
            }
        }
        else if(horizontal > 0)
        {
            if (!isFacingRight)
            {
                isFacingRight = true;
                transform.localScale = new Vector3(transform.localScale.x * -1
                    , transform.localScale.y, transform.localScale.z);
                playerHealth.healthSlider.transform.localScale = new Vector3(playerHealth.healthSlider.transform.localScale.x * -1
                         , playerHealth.healthSlider.transform.localScale.y, playerHealth.healthSlider.transform.localScale.z);
            }
        }

        //Player Attack
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!attackReset)
            {
                attackReset = true;
                anim.SetTrigger("Attack");

                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject.CompareTag("Enemy"))
                    {
                       EnemyHealth enemy = colliders[i].GetComponent<EnemyHealth>();
                        enemy.TakeDamage(damage);
                        //Damage enemy
                    }
                }
            }
        }

        if (attackReset)
        {
            time += Time.deltaTime;
            if(time >= attackDelay)
            {
                time = 0f;
                attackReset = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (playerHealth.dead)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, stopSmoothness);
        }
        else
        {
            if (horizontal > 0 || horizontal < 0)
                rb.AddForce(horizontal * speed * Time.deltaTime * Vector3.right, ForceMode2D.Impulse);
            else
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, stopSmoothness);
        }
    }

    private void LateUpdate()
    {
        anim.SetFloat("Velocity", rb.velocity.magnitude);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
