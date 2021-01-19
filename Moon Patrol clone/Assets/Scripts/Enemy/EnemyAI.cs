using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidbody2d;

    private float _latestDirectionChangeTime;
    private readonly float _directionChangeTime = 0.5f;
    private float _characterVelocity = 12f;
    
    private Vector2 _movementDirection;
    private Vector2 _movementPerSecond;

    private Vector2 _currentPosition;
    private Vector2 _targetPosition;


    private bool reverse = false;
    private void Start() {
        _latestDirectionChangeTime = 0f;
        CalcuateNewMovementVector();
    }

    private void CalcuateNewMovementVector() {
        Debug.Log("CALCULATE NEW MOVEMENT VECTOR");
        if(reverse == true) {
            _movementDirection = -_movementDirection;
            _movementPerSecond = _movementDirection * _characterVelocity;
            _targetPosition = new Vector2(_movementDirection.x + 5f,
                _movementDirection.y + 5f);
            return;
        }
        _movementDirection = new Vector2(Random.Range(-12f, 22f), Random.Range(-1f, 1f)).normalized;
        _movementPerSecond = _movementDirection * _characterVelocity;
        reverse = false;
        
        _targetPosition = new Vector2(-_movementDirection.x + 5f,
            -_movementDirection.y + 5f);
    }

    void Update() {
        // TODO remove hardcoded speed
        rigidbody2d.velocity = new Vector2(5f, 0);

        if (Time.time - _latestDirectionChangeTime > _directionChangeTime && reverse == false) {
            _latestDirectionChangeTime = Time.time;
            CalcuateNewMovementVector();
            reverse = false;
            
            transform.position = new Vector2(transform.position.x + (_movementPerSecond.x * Time.deltaTime),
                transform.position.y + (_movementPerSecond.y * Time.deltaTime));
        }
        
        if (Time.time - _latestDirectionChangeTime > _directionChangeTime && reverse) {
            Debug.Log("REVERSE");
            _latestDirectionChangeTime = Time.time;
            CalcuateNewMovementVector();
            reverse = false;
            transform.position = new Vector2(transform.position.x + (_movementPerSecond.x * Time.deltaTime),
                transform.position.y + (_movementPerSecond.y * Time.deltaTime));
        }
        transform.position = new Vector2(transform.position.x + (_movementPerSecond.x * Time.deltaTime),
            transform.position.y + (_movementPerSecond.y * Time.deltaTime));
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, _targetPosition);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "AiWalls") {
            Debug.Log($"AI WALLS TIME {_latestDirectionChangeTime}");
            reverse = true;
            Debug.Log("AI WALL");
            CalcuateNewMovementVector();
        }
    }
}