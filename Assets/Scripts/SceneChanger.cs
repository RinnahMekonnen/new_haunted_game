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
    public void Scene4() {  
        SceneManager.LoadScene("BossRoom");  
    }  
} 