using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public int level;
    private static LevelData _instance;
    public static LevelData Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        { 
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
