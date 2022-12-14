using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour {  
    
    public void Scene1() {  
        SceneManager.LoadScene("MAIN MENU");  
    }  
    public void Scene2() {  
        SceneManager.LoadScene("Big Monster Room");  
    }  
    public void Scene3() {  
        SceneManager.LoadScene("room 2");  
    }
<<<<<<< HEAD
    public void Scene4() {  
        SceneManager.LoadScene("BossRoom");  
    }  
} 
=======

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
>>>>>>> 835d2adf40e08f060e498996c0ad67fe435a9904
