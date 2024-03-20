using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _reflectionRandomalization;
    

    private Vector2 lastRigitBodyVelocity;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        SendBallRandomDirection();
    }

    private void SendBallRandomDirection()
    {
        _rigidbody2D.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * _speed;
        lastRigitBodyVelocity = _rigidbody2D.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidbody2D.velocity.magnitude < .1f)
        {
            recetballs();
        }
    }

    private void recetballs()
    {
        _rigidbody2D.velocity = Vector3.zero;
        _rigidbody2D.simulated = false;
        _rigidbody2D.transform.position = Vector3.zero;
        _rigidbody2D.simulated = true;
        SendBallRandomDirection();
    }

    private void OnCollisionEnter(Collision other)
    {
        var randomOffset = new Vector2(Random.Range(-_reflectionRandomalization, _reflectionRandomalization), Random.Range(-_reflectionRandomalization, _reflectionRandomalization));
        var reflectedVector = Vector2.Reflect(lastRigitBodyVelocity, (other.contacts[0].normal + randomOffset).normalized);
        lastRigitBodyVelocity = _rigidbody2D.velocity;
    }
}
