using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action OnGameStart;
    public event Action OnGameOver;

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
        GameStart();
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
        print("Game Over");
    }

    public void GameStart()
    {
        OnGameStart?.Invoke();
    }
}
