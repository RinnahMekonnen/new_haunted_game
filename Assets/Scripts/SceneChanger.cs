using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void NextScene()
    {
        SceneManager.LoadScene("BossRoom");
    }

    public void ToRoom2()
    {
        SceneManager.LoadScene("room 2");
    }

    public void ToBigMonsterRoom()
    {
        SceneManager.LoadScene("Big Monster Room");
    }

    public void ToRoomone()
    {
        SceneManager.LoadScene("room one");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MAIN MENU");
    }

}
