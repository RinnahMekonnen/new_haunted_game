using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class room2door : MonoBehaviour
{

    private bool canChangeRooms = false;
    SceneChanger sceneChanger;
    public GameObject bat1;
    public GameObject bat2;
    public GameObject bat3;
    

    // Start is called before the first frame update
    void Start()
    {
        sceneChanger = GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0.4 && canChangeRooms)
        {
            sceneChanger.Scene2();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (bat1.IsDestroyed()&&bat2.IsDestroyed()&&bat3.IsDestroyed())
            {
                canChangeRooms = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canChangeRooms = false;
        }
    }
}
