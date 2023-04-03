using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("AI:")]
    [SerializeField] private Transform[] _movePoints;
    [Header("Movement:")]
    [SerializeField] private float _moveForce = 20f;

    private Rigidbody2D _rigidbody;
    private int _targetIndex = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        for (int i = 0; i < _movePoints.Length; i++)
        {
            _movePoints[i].parent = null;
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float xPos = transform.position.x;
        float distance = _movePoints[_targetIndex].position.x - xPos;
        if (distance < 1f && distance > -1f)
        {
            _targetIndex++;
            if (_targetIndex > _movePoints.Length - 1) _targetIndex = 0;
        }

        if (distance < 0f) _rigidbody.AddForce(Vector2.left * _moveForce);
        else _rigidbody.AddForce(Vector2.right * _moveForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            collision.gameObject.GetComponent<Player>().Respawn();
        }
    }
}
