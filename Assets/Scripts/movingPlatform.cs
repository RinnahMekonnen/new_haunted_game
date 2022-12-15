

//  Borrowed from https://github.com/jddunn/random-movement-AI-unity/blob/master/RandomMovement.cs
// Random movement script for Unity GameObjects
//  GameObjects with this script attached will constantly move at a random range of speed
//  and rotate at a random range of angles, and upon collision with walls or other GameObject tags,
//  the movement direction will change.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {

    //public AudioClip AlienScream;
    public float minSpeed = 1.5f;  // minimum range of speed to move
    public float maxSpeed = 3f;  // maximum range of speed to move
    float speed;     // speed is a constantly changing value from the random range of minSpeed and maxSpeed 
    
    public string [] collisionTags;             //  What are the GO tags that will act as colliders that trigger a
                                                //  direction change? Tags like for walls, room objects, etc.
    public AudioClip collisionSound;

    float step = Mathf.PI / 60;
    float timeVar = 0;
    float rotationRange = 120;                  //  How far should the object rotate to find a new direction?
    float baseDirection = 0;

    Vector3 randomDirection;                // Random, constantly changing direction from a narrow range for natural motion


    void OnCollisionEnter (Collision col) {

        if (col.gameObject.tag == "Platform") {                   //  Tag it with a wall or other object
            GetComponent<AudioSource>().PlayOneShot (collisionSound, 2.0f);         //  Plays a sound on collision
            baseDirection = baseDirection + Random.Range (-8, 8);   // Switch to a new direction on collision

    }
}

    void Update() {
     
        randomDirection = new Vector3(0, Mathf.Sin(timeVar) * (rotationRange / 2) + baseDirection, 0); //   Moving at random angles 
        timeVar += step;
        speed = Random.Range(minSpeed, maxSpeed);              //      Change this range of numbers to change speed
        //speed = 1.1f;
        //speed = 0.00000000000000000000000000000000000000000000000000000000000000001f;

        //GetComponent<Rigidbody2D>().AddForce(transform.forward * speed);
        GetComponent<Rigidbody2D>().AddForce(transform.forward * speed);
        transform.Rotate(randomDirection * Time.deltaTime * 0.50f);        
        }
    }

    
    /* void OnCollisionEnter(Collision collision)              //  Another collision example {
        baseDirection = baseDirection + Random.Range(-30.0f, 30.0f);
        if (collision.gameObject.name == "Refined Controller")        //  Collides with player
        {
            Application.LoadLevel("Title");               //  Reload the level if the player is hit
        }
    } */