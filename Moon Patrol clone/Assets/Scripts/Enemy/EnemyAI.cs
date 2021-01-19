using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour {
    private float _latestDirectionChangeTime;
    private float _directionChangeTime = 1f;
    private float _characterVelocity = 3f;
    
    private Vector2 _movementDirection;
    private Vector2 _movementPerSecond;


    private void Start() {
        _latestDirectionChangeTime = 0f;
        Debug.LogWarning(_latestDirectionChangeTime);
        CalcuateNewMovementVector(false);
    }

    private void CalcuateNewMovementVector(bool reverse) {
        _movementDirection = new Vector2(Random.Range(-1f, 1f), 0).normalized;
        _movementPerSecond = _movementDirection * _characterVelocity;
    }
    void Update() {
        if (Time.time - _latestDirectionChangeTime > _directionChangeTime) {
            _latestDirectionChangeTime = Time.time;
            CalcuateNewMovementVector(false);
        }
        transform.position = new Vector2(transform.position.x + (_movementPerSecond.x * Time.deltaTime),
            transform.position.y + (_movementPerSecond.y * Time.deltaTime));
    }

    private void OnTriggerStay2D(Collider2D col) {
        if (col.name == "AiWalls") {
            Debug.Log("reverse");
            _movementDirection = -_movementDirection;
            _movementPerSecond = _movementDirection * (_characterVelocity + 2);
            _latestDirectionChangeTime = Time.time;
        }
    }
}