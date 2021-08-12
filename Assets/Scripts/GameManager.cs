using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action OnGameStart;
    public event Action OnGameOver;
    
    private bool _isPlayable;
    
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isPlayable)
        {
            _isPlayable = true;
            GameStart();
        }
    }

    public void GameStart()
    {
        OnGameStart?.Invoke();
    }
    
    public void GameOver()
    {
        OnGameOver?.Invoke();
        _isPlayable = false;
        print("Game Over");
    }

}
