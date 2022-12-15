using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useItem : MonoBehaviour
{
    
    private healthScript health;
    public GameObject item;
    
    
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<healthScript>();
     
    }

    

}
