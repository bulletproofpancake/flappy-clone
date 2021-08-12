using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Text _instructionsDisplay;
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
        _instructions = _instructionsDisplay.text;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isPlayable)
        {
            _isPlayable = true;
            GameStart();
        }
        
        _instructionsDisplay.text = _isPlayable ? string.Empty : _instructions;
    }

    public void GameStart()
    {
        OnGameStart?.Invoke();
    }
    
    public void GameOver()
    {
        OnGameOver?.Invoke();
        _isPlayable = false;
    }

}
