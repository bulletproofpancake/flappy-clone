using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + Vector2.left * speed * Time.fixedDeltaTime);
    }
}
