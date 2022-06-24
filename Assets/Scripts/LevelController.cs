using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private readonly string GAME_OVER_SCENE_NAME = "Scenes/GameOver";
    private readonly int NUMBER_OF_GAME_LEVELS = 40;
    
    // UI elements
    [SerializeField] int blocksCounter;

    // state
    private SceneLoader _sceneLoader;

    private LoadLevelData _loadLevelData;
    private LevelData _levelData;

    private Paddle _paddle;
    private Ball _ball;
    private void Start()
    {
        _loadLevelData = FindObjectOfType<LoadLevelData>();
        _levelData = FindObjectOfType<LevelData>();
        _paddle = FindObjectOfType<Paddle>();
        _ball = FindObjectOfType<Ball>();
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void IncrementBlocksCounter()
    {
        blocksCounter++;
    }
    
    public void DecrementBlocksCounter()
    {
        blocksCounter--;

        if (blocksCounter <= 0)
        {
            var gameSession = GameSession.Instance;
            
            // check for game over
            if (gameSession.GameLevel >= NUMBER_OF_GAME_LEVELS)
            {
                _sceneLoader.LoadSceneByName(GAME_OVER_SCENE_NAME);
            }

            // increases game level

            int stars = gameSession.PlayerLives switch
            {
                > 2 => 3,
                > 0 => 2,
                _ => 1
            };
            if(stars>PlayerPrefs.GetInt("Lv"+gameSession.GameLevel))
            {
                PlayerPrefs.SetInt("Lv"+gameSession.GameLevel,stars);
            }
            _levelData.level += 1;
            ReloadLevel();
        }
    }


    void ReloadLevel()
    { 
        _paddle.ResetPaddlePosition();
        _ball.ResetBallToPaddle();
        _loadLevelData.ReturnAllGameObjectToPool();
        _loadLevelData.LoadDataFromCsv();
    }
}
