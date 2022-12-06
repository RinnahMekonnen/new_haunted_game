using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{

    private Inventory _inventory;
    public int i;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            _inventory.isFull[i] = false;
        }
    }

    public void dropItem()
    {
        foreach (Transform child  in transform )
        {
            child.GetComponent<spawn>().SpawnDroppeditem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
