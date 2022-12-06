using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public GameObject item;
    private Transform player;

    public void SpawnDroppeditem()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDropped()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 3);
        Instantiate(item, playerPos, Quaternion.identity);
    }


}
