using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private Text scoreDisplay;
    [SerializeField] private Text highScoreDisplay;
    
    private int _score;
    private int _hiScore;

    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += SetHighScore;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= SetHighScore;
    }

    private void Start()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreDisplay.text = $"Score: {_score:000}";
    }

    public void AddScore()
    {
        _score++;
        UpdateScore();
    }

    public void AddScore(int points)
    {
        _score += points;
        UpdateScore();
    }

    private void SetHighScore()
    {
        if (_score > _hiScore)
            _hiScore = _score;
        
        highScoreDisplay.text = $"Hi-Score: {_hiScore:000}";
        ClearScore();
    }
    
    private void ClearScore()
    {
        _score = 0;
        UpdateScore();
    }
}