using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelData : MonoBehaviour
{
    public List<LevelData> _levels = new List<LevelData>();
    void Start()
    {
        TextAsset levelData = Resources.Load<TextAsset>("LevelData");
        string[] data = levelData.text.Split(new char[] { '\n' });
        for (int i =1; i<data.Length-1;i++ )
        {
            string[] row = data[i].Split(new char[] { ',' });
            if (row[1] != "")
            {
                LevelData lvl = new LevelData();
                int.TryParse(row[0], out lvl.id);
                int.TryParse(row[1], out lvl.stars);
                int.TryParse(row[2], out lvl.canPlay);
                _levels.Add(lvl);
            }
        }

        foreach (var level in _levels)
        {
            Debug.Log(level.id);
            Debug.Log(level.stars);
            Debug.Log(level.canPlay);
            Debug.Log(" \n");
        }
    }
    void Update()
    {
        
    }
}
