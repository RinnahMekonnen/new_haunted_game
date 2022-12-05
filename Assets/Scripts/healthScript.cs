using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{
    public int PlayerHealth = 5;
    //public Text healthText;

    private void Update()
    {
        //healthText.text = health.ToString();

        if (Input.GetKeyDown(KeyCode.Space) && PlayerHealth>0)
        {
            PlayerHealth--;
        }
    }

    public void TakeDamage(int attackDamage)
    {
        PlayerHealth -= attackDamage;
    }
}
