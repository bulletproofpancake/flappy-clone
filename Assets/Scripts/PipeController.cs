using System;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += Deactivate;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= Deactivate;
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + Vector2.left * speed * Time.fixedDeltaTime);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
