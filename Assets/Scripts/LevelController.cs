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
    
    private void Start()
    {
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
           
            int stars;
            if (gameSession.PlayerLives == 0)
            {
                stars = 1;
            }else if (gameSession.PlayerLives > 0)
            {
                stars = 2;
            }
            else
            {
                stars = 3;
            }
            if(stars>PlayerPrefs.GetInt("Lv"+gameSession.GameLevel))
            {
                PlayerPrefs.SetInt("Lv"+gameSession.GameLevel,stars);
            }
            
            gameSession.GameLevel++;
            _sceneLoader.LoadNextScene();
        }
    }
    
    
}
