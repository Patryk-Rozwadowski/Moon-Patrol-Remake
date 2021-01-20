using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour {
    private float _latestDirectionChangeTime;
    private float _directionChangeTime = 1f;
    private float _characterVelocity = 5f;
    
    private Vector2 _movementDirection;
    private Vector2 _movementPerSecond;

    private bool reverse;
    private void Start() {
        _latestDirectionChangeTime = 0f;
        Debug.LogWarning(_latestDirectionChangeTime);
        CalcuateNewMovementVector();
    }

    private void CalcuateNewMovementVector() {
        _movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        _movementPerSecond = new Vector2(_movementDirection.x * _characterVelocity, _movementDirection.y/4);
    }
    void FixedUpdate() {
        if (Time.time - _latestDirectionChangeTime > _directionChangeTime) {
            _latestDirectionChangeTime = Time.time;
            CalcuateNewMovementVector();
        }
        transform.position = new Vector2(transform.position.x + (_movementPerSecond.x * Time.deltaTime),
            transform.position.y + (_movementPerSecond.y * Time.deltaTime));

        // if (transform.localPosition.x <= 15 ) {
        //     _latestDirectionChangeTime = Time.time;
        //     CalcuateNewMovementVector();
        // };
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.name == "AiWalls") {
            Debug.Log("reverse");
      

            Vector2 inDirection = _movementDirection;
            Vector2 inNormal = collision.contacts[0].normal;
            Vector2 newVelocity = Vector2.Reflect(inDirection, inNormal);
            _movementDirection = newVelocity;
            _movementPerSecond = new Vector2(_movementDirection.x * 5, _movementDirection.y); ;
            _latestDirectionChangeTime = 0;
        }
        //
        // if (collision.gameObject.tag == "Enemy") {
        //     
        // }
            
      
    }
}