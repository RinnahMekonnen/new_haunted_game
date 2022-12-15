using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    private healthScript health;
    
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<healthScript>();
     
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            useHealthPotion();
        }
    }

    public void useHealthPotion()
    {
        if (health.PlayerHealth < 5)
        {
            for (int i = isFull.Length-1; i >= 0 ; i--)
            {
                if (isFull[i])
                {
                    Destroy(slots[i].transform.GetChild(0).gameObject);
                    health.addHeart();
                    break;
                }
                
            }
            
        }
    }
    
   

    
    
}
