using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room2door : MonoBehaviour
{

    SceneChanger sceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        sceneChanger = GetComponent<SceneChanger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneChanger.Scene2();
    }
}
