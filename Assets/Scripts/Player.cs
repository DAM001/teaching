using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveForce = 20f;
    [SerializeField] private float _jumpForce = 100f;
    [Header("Death:")]
    [SerializeField] private float _minYDeathZone = -100f;

    private Rigidbody2D _rigidbody;
    private Vector2 _startPos;
    private bool _isGrounded = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < _minYDeathZone) Respawn();

        if (!_isGrounded) return;

        if (Input.GetKey(KeyCode.D)) _rigidbody.AddForce(Vector2.right * _moveForce);
        if (Input.GetKey(KeyCode.A)) _rigidbody.AddForce(Vector2.left * _moveForce);
    }

    public void Respawn()
    {
        transform.position = _startPos;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0f;
    }

    private void Update()
    {
        if (!_isGrounded) return;

        if (Input.GetKeyDown(KeyCode.Space)) _rigidbody.AddForce(Vector2.up * _jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
}