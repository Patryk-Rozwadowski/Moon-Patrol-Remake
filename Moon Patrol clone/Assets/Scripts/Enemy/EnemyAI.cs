using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour {
    private float _latestDirectionChangeTime;
    private float _directionChangeTime = 2f;
    private float _characterVelocity = 5f;
    
    private Vector2 _movementDirection;
    private Vector2 _movementPerSecond;

    private bool reverse = false;
    private void Start() {
        _latestDirectionChangeTime = 0f;
        Debug.LogWarning(_latestDirectionChangeTime);
        CalcuateNewMovementVector();
    }

    private void CalcuateNewMovementVector() {
        _movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        _movementPerSecond = new Vector2(_movementDirection.x * _characterVelocity, _movementDirection.y/2);
    }
    
    
    void Update() {
        if (Time.time - _latestDirectionChangeTime > _directionChangeTime) reverse = false;
        if (Time.time - _latestDirectionChangeTime > _directionChangeTime && reverse != true) {
            _latestDirectionChangeTime = Time.time;
            CalcuateNewMovementVector();
        }
        transform.position = new Vector2(transform.position.x + (_movementPerSecond.x * Time.deltaTime),
            transform.position.y + (_movementPerSecond.y * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "AiWalls") {
            // Debug.Log("reverse");
            _movementDirection = -_movementDirection;
            _movementPerSecond = new Vector2(_movementDirection.x * 4, _movementDirection.y); ;
            reverse = true;
            Debug.Log(reverse);
        }
    }
    
    
}