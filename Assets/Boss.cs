using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Transform player;
    public bool isFlipped = false;
    public float offset = 0;
    public float secoffset = 1;

    Rigidbody2D rb;

    public void LookAtPlayer()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x + offset && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);

            Vector2 newPos = new Vector2(rb.position.x - offset - secoffset, rb.position.y);
            transform.position = newPos;

            isFlipped = false;
            offset *= -1;
            secoffset *= -1;    
        }
        else if (transform.position.x < player.position.x + offset && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);

            Vector2 newPos = new Vector2(rb.position.x - offset - secoffset, rb.position.y);
            transform.position = newPos;

            isFlipped = true;
            offset *= -1;
            secoffset *= -1;
        }
    }
}