using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    
    private healthScript health;
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    
    public void useItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
