using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    //set target from inspector instead of looking in Update
    public Transform target;
    public float speed = 3f;


    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        target = p.transform;
    }

    void LateUpdate()
    {

        //rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

    }

}
