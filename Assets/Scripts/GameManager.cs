using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Text instructionsDisplay;
    private string _instructions;
    
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

    private void Start()
    {
        // instructions are cached so that what is written in the editor is used
        _instructions = instructionsDisplay.text;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isPlayable)
        {
            _isPlayable = true;
            GameStart();
        }
        
        instructionsDisplay.text = _isPlayable ? string.Empty : _instructions;
    }

    private void GameStart()
    {
        OnGameStart?.Invoke();
    }
    
    public void GameOver()
    {
        OnGameOver?.Invoke();
        _isPlayable = false;
    }

}
