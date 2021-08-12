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

    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += ClearScore;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= ClearScore;
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

    private void ClearScore()
    {
        _score = 0;
        UpdateScore();
    }
}