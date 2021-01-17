using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidbody2d;

    private float _latestDirectionChangeTime;
    private readonly float _directionChangeTime = 1f;
    private float _characterVelocity = 2f;
    private Vector2 _movementDirection;
    private Vector2 _movementPerSecond;

    private void Start(){
        _latestDirectionChangeTime = 0f;
        CalcuateNewMovementVector();
    }
 
    private void CalcuateNewMovementVector(){
        _movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        _movementPerSecond = _movementDirection * _characterVelocity;
    }
 
    void Update(){
        rigidbody2d.velocity = new Vector2(5f, 0);
        if (Time.time - _latestDirectionChangeTime > _directionChangeTime){
            _latestDirectionChangeTime = Time.time;
            CalcuateNewMovementVector();
        }
     
        transform.position = new Vector2(transform.position.x + (_movementPerSecond.x * Time.deltaTime), 
            transform.position.y + (_movementPerSecond.y * Time.deltaTime));
 
    }
    
}