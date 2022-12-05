using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    // GameObject enemy
    healthScript enemy;
    public int attackDamage = 10;

    public float initialHealth = 100.0f;

    private float currentHealth;

    void Start()
    {
        currentHealth = initialHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //get from collision the object you collided with
        {
            // get the object.getcompionent,EnemyDamage>
            // set enemy to the one above

            enemy = collision.GetComponent<healthScript>();
            enemy.TakeDamage(attackDamage);
        }
    }
}



  