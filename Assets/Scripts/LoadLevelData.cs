using System;
using System.Collections;
using UnityEngine;

using UnityEngine.Pooling;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LoadLevelData : MonoBehaviour
{
    private GameSession _gameSession;
    private Ball _ball;
    private LevelData _levelData;
    [SerializeField] private GameObjectSpawner spawner;
    private int level;

    void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _gameSession = FindObjectOfType<GameSession>();
        _levelData = FindObjectOfType<LevelData>();
        spawner.Initialize();
        LoadDataFromCsv();
    }
    public void LoadDataFromCsv()
    {
        TextAsset levelData = Resources.Load<TextAsset>("Level_"+_levelData.level);
        string[] data = levelData.text.Split(new[] { '\n' });
        string[] stat = data[0].Split(new[] { ',' });
        int.TryParse(stat[0], out var lives);
        _gameSession.PlayerLives = lives;
        StartCoroutine(LateStart(0.1f,_levelData.level));
        float.TryParse(stat[1], out var ballSpeed);
        _ball.speed = ballSpeed;
        GenerateBlocks(data);
    }

    IEnumerator LateStart(float time, int levelToLoad)
    {
        yield return new WaitForSeconds(time);
        _gameSession.GameLevel = levelToLoad;
    }
    void GenerateBlocks(string[] data)
    {
        Vector3 position = new Vector3(0.5f, 10.5f, 0f);
        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new[] { ',' });
            for (int j = 0; j < row.Length; j++)
            {
                string key = row[j].TrimEnd();
                if (position.x > 15.5f)
                {
                    position.y -= 1f;
                    position.x = 0.5f;
                }
                if (!key.Equals("0"))
                {
                    GetGameObjectFromPool(key,position);
                }
                position.x += 1;
            }
        }
    }
    void GetGameObjectFromPool(string key,Vector3 position)
    {
        var go = spawner.Get(key, Vector3.zero, Quaternion.identity);
        go.transform.position = position;
        go.SetActive(true);
        go.transform.SetParent(this.gameObject.transform);
    }
    public void ReturnAllGameObjectToPool()
    {
        spawner.ReturnAll();
    }
}
