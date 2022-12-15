using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSavedData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
