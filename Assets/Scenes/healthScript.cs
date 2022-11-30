using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{
    private int health = 5;
    public Text healthText;

    private void Update()
    {
        healthText.text = health.ToString();

        if (Input.GetKeyDown(KeyCode.Space) && health>0)
        {
            health--;
        }
    }
}
