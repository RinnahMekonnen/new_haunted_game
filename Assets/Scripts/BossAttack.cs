using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour
{

    public int attackDamage = 10;
    public float initialHealth = 100.0f;
    public bool contact = false;

    private float currentHealth;
    healthScript enemy;
    Boss boss;

    void Start()
    {
        currentHealth = initialHealth;
        boss = GetComponent<Boss>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //get from collision the object you collided with
        {
            contact = true;
            if (boss.isAttacking)
            {
                // get the object.getcompionent,EnemyDamage>
                // set enemy to the one above
                enemy = collision.GetComponent<healthScript>();
                enemy.TakeDamage(attackDamage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            contact = false;
        }
    }
}
