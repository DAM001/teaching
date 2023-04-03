using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Vector3 _offset = new Vector3(0f, 0f, -10f);
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 0.25f;

    private Vector3 _velocity = Vector3.zero;

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _target.position + _offset, ref _velocity, _speed);
    }
}
