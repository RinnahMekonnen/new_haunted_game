using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMRdoor : MonoBehaviour
{

    private bool canChangeRooms = false;
    SceneChanger sceneChanger;

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
            sceneChanger.Scene4();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canChangeRooms = true;
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
