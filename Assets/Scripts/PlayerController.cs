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
                _isPowerUpActive = false;
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
            ScoreManager.Instance.AddScore();
        if (other.CompareTag("PowerUp"))
        {
            _isPowerUpActive = true;
            _activePowerUp = other.GetComponent<PowerUp>().Data;
            ScoreManager.Instance.AddScore(_activePowerUp.Points);
            PowerUpScale(_activePowerUp.Size);
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