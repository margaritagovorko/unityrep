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
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(SendBallRandomDirection());
    }

    private IEnumerator SendBallRandomDirection()
    {
        var randomX = Random.Range(-1f,1f);
        while (randomX is -1 or 0 or 1)
        {
            randomX = Random.Range(-1f, 1f);
            yield return null;
        }
        var randomY = Random.Range(-1f, 1f);
        while (randomY is -1 or 0 or 1)
        {
            randomY = Random.Range(-1f, 1f);
            yield return null;
        }
        _rigidbody2D.velocity = new Vector2(randomX, randomY).normalized * _speed;
        lastRigitBodyVelocity = _rigidbody2D.velocity;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            RecetBall();
        }

        if(_rigidbody2D.velocity.magnitude < .1f)
        {
            RecetBall();
        }
    }

    private void RecetBall()
    {
        _rigidbody2D.velocity = Vector3.zero;
        _rigidbody2D.simulated = false;
        _rigidbody2D.transform.position = Vector3.zero;
        _rigidbody2D.simulated = true;
        StartCoroutine(SendBallRandomDirection());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var randomOffset = new Vector2(Random.Range(-_reflectionRandomalization, 0), Random.Range(-_reflectionRandomalization, 0));
        var reflectedVector = Vector2.Reflect(lastRigitBodyVelocity, (other.contacts[0].normal + randomOffset).normalized);
        lastRigitBodyVelocity = _rigidbody2D.velocity;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Score");
        if (transform.position.x<0)
        {
            GameManager.leftPlayerScore++;
        }
        if(transform.position.x>0){
            GameManager.rightPlayerScore++;
        }
        RecetBall();
    }
}
