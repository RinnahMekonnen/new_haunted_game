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
        bool isPotion = false;
        foreach (bool bl in isFull)
        {
            if (bl)
            {
                isPotion = true;
                break;
            }
        }
        
        if (health.PlayerHealth < 5&& isPotion)
        {
            for (int i = isFull.Length-1; i >= 0 ; i--)
            {
                if (isFull[i])
                {
                    Destroy(slots[i].transform.GetChild(0).gameObject);
                    isFull[i] = false;
                    health.addHeart();
                    break;
                }
                
            }
            
        }
    }
    
   

    
    
}
