﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // state
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerScoreText.text = playerScore.ToString();
    }

    /**
     * Updates player score with given points and also updates the UI score.
     */
    public void AddToPlayerScore(int points)
    {
        playerScore += points;
        playerScoreText.text = playerScore.ToString();
    }
}