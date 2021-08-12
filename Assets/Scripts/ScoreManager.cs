using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreDisplay;
    
    public static ScoreManager Instance;
    
    private int _score;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            if (Instance != this)
                Destroy(gameObject);
        }
    }

    private void Start()
    {
        scoreDisplay.text = $"Score: {_score:000}";
    }

    public void AddScore()
    {
        _score++;
        scoreDisplay.text = $"Score: {_score:000}";
    }

    public void AddScore(int points)
    {
        _score += points;
        scoreDisplay.text = $"Score: {_score:000}";
    }
    
    public void ClearScore()
    {
        _score = 0;
        scoreDisplay.text = $"Score: {_score:000}";
    }
}
