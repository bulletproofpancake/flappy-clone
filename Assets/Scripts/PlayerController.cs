using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private Rigidbody2D _rigidbody;
    
    private bool _isPowerUpActive;
    private PowerUpData _activePowerUp;
    private float _powerUpTimer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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
            }
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Pipe"))
            GameManager.Instance.GameOver();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PipeScore"))
        {
            if(!_isPowerUpActive)
                ScoreManager.Instance.AddScore();
            else
                ScoreManager.Instance.AddScore(_activePowerUp.Points);
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
            other.gameObject.SetActive(false);
        }
    }
    
    private void PowerUpScale(Vector2 size)
    {
        transform.localScale = size;
    }

    private void NormalScale()
    {
        transform.localScale = Vector3.one;
    }
}