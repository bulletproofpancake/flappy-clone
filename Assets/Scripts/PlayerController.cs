using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private Rigidbody2D _rigidbody;
    
    private bool _isPowerUpActive;
    private PowerUpData _activePowerUp;
    private float _powerUpTimer;
    private bool _isPlayable;
    private Vector2 _startingPosition;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startingPosition = transform.position;
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameStart += BecomePlayable;
        GameManager.Instance.OnGameOver += BecomeUnplayable;
        GameManager.Instance.OnGameOver += ResetPlayer;
    }
    
    private void OnDisable()
    {
        GameManager.Instance.OnGameStart -= BecomePlayable;
        GameManager.Instance.OnGameOver -= BecomeUnplayable;
        GameManager.Instance.OnGameOver -= ResetPlayer;
    }
    
    private void Update()
    {
        // When the game is not playable, the player cannot move
        _rigidbody.bodyType = !_isPlayable ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
        
        if (!_isPlayable) return;
        
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        
        if (!_isPowerUpActive)
        {
            NormalScale();
            _powerUpTimer = 0f;
        }
        else
        {
            if (_activePowerUp == null) return;
            
            if (_powerUpTimer < _activePowerUp.ActiveTime)
                _powerUpTimer += Time.deltaTime;
            else
            {
                _isPowerUpActive = false;
                _activePowerUp = null;
                AudioManager.Instance.Play("PowerUpOff");
            }
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * jumpForce;
        AudioManager.Instance.Play("Jump");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Pipe") || other.collider.CompareTag("Ground"))
        {
            AudioManager.Instance.Play("Fail");
            GameManager.Instance.GameOver();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PipeScore"))
        {
            if(!_isPowerUpActive)
                ScoreManager.Instance.AddScore();
            else
                ScoreManager.Instance.AddScore(_activePowerUp.Points);
            AudioManager.Instance.Play("Score");
        }
        
        if (other.CompareTag("PowerUp"))
        {
            var powerUp = other.GetComponent<PowerUp>();
            if(_activePowerUp == null && !_isPowerUpActive)
            {
                _isPowerUpActive = true;
                _activePowerUp = powerUp.Data;
                PowerUpScale(_activePowerUp.Size);
            }
            else
            {
                ScoreManager.Instance.AddScore(powerUp.Data.Points);
            }
            //Only works if the name of the power up scriptable object is the same as the name in the audioManager
            AudioManager.Instance.Play(_activePowerUp.name);
            other.gameObject.SetActive(false);
        }
    }
    
    private void PowerUpScale(Vector2 size) { transform.localScale = size; }
    private void NormalScale() { transform.localScale = Vector3.one; }

    private void BecomePlayable() { _isPlayable = true; }
    private void BecomeUnplayable() { _isPlayable = false; }

    private void ResetPlayer()
    {
        transform.position = _startingPosition;
        _activePowerUp = null;
        _isPowerUpActive = false;
        NormalScale();
    }

}