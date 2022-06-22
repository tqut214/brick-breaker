using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;
using Newtonsoft.Json;

public class JsonData : MonoBehaviour
{
    private List <LevelData> _levelData = new List<LevelData>();
    private string fileName = "LevelData.json";
    private string path;
    void Start()
    {
        path = Application.persistentDataPath + "/" + fileName;
        Debug.Log(path);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(S))*/
        {
            SaveData();
        }
    }

    void ReadData()
    {
        
    }

    void SaveData()
    {
       
    }
}
