using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidbody2d;

    private float _latestDirectionChangeTime;
    private float _directionChangeTime = 1f;
    private float _characterVelocity = 5f;
    
    private Vector2 _movementDirection;
    private Vector2 _movementPerSecond;

    private Vector2 _currentPosition;
    private Vector2 _targetPosition;

    private Vector2 _lastVector;

    // private bool reverse = false;
    private void Start() {
        _latestDirectionChangeTime = 0f;
        Debug.LogWarning(_latestDirectionChangeTime);
        CalcuateNewMovementVector(false);
    }

    private void CalcuateNewMovementVector(bool reverse) {
        if(reverse) {
            _movementDirection =  Vector3.Reflect(_movementDirection, -_movementDirection);
            Debug.LogWarning($"REVERSE CALCULATE CURRENT: {_movementDirection.x} {_movementDirection.y}");
            _movementPerSecond = _movementDirection * _characterVelocity;
            return;
        }
        _movementDirection = new Vector2(Random.Range(-12f, 22f), Random.Range(-1f, 1f)).normalized;
        _lastVector = _movementDirection;
        _movementPerSecond = _movementDirection * _characterVelocity;
    }
// TODO WYSKAKUJE POZA COLLIDER
    void Update() {
        if (Time.time - _latestDirectionChangeTime > _directionChangeTime) {
            _latestDirectionChangeTime = Time.time;
            CalcuateNewMovementVector(false);
        }
        transform.position = new Vector2(transform.position.x + (_movementPerSecond.x * Time.deltaTime),
            transform.position.y + (_movementPerSecond.y * Time.deltaTime));
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.name == "AiWalls") {
            Debug.Log("AI WALL");
            CalcuateNewMovementVector(true);
        }
    }
}