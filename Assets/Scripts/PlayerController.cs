using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 minScale, maxScale;
    
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if(Input.GetKeyDown(KeyCode.Q))
            ScaleDown();
        if(Input.GetKeyDown(KeyCode.W))
            ScaleUp();
        if(Input.GetKeyDown(KeyCode.E))
            ScaleOne();
        
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground") || other.collider.CompareTag("Pipe"))
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PipeScore"))
            ScoreManager.Instance.AddScore();
    }
    
    private void ScaleDown()
    {
        transform.localScale = new Vector3(minScale.x, minScale.y);
    }

    private void ScaleUp()
    {
        transform.localScale = new Vector3(maxScale.x, maxScale.y);
    }

    private void ScaleOne()
    {
        transform.localScale = Vector3.one;
    }
}