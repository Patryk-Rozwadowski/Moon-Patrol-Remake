using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy {
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemyAI : MonoBehaviour {
        
        // TODO refactor
        private float _latestDirectionChangeTime;
        private float _directionChangeTime = 2f;
        
        // TODO take from enemyParamsSO
        private float _characterVelocity = 5f;
    
        private Vector2 _movementDirection;
        private Vector2 _movementPerSecond;

        private bool _reverse, _flee;

        public void EnemyFlee() {
            _flee = true;
            _characterVelocity = 10f;
            _movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0, 1f));
        }
        
        private void Start() {
            _latestDirectionChangeTime = 0f;
            CalcuateNewMovementVector();
        }

        private void CalcuateNewMovementVector() {
            _movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _movementPerSecond = new Vector2(_movementDirection.x * _characterVelocity, _movementDirection.y / 2);
        }


        void Update() {
            transform.position = new Vector2(transform.position.x + (_movementPerSecond.x * Time.deltaTime),
                transform.position.y + (_movementPerSecond.y * Time.deltaTime));
            if (_flee) return;
            if (Time.time - _latestDirectionChangeTime > _directionChangeTime) _reverse = false;
            if (Time.time - _latestDirectionChangeTime > _directionChangeTime && _reverse != true) {
                _latestDirectionChangeTime = Time.time;
                CalcuateNewMovementVector();
            }

           
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.name == "AiWalls" && _flee) Destroy(gameObject, 2f); 
            if (collision.gameObject.name == "AiWalls" && _flee == false) {
                _movementDirection = -_movementDirection;
                _movementPerSecond = new Vector2(_movementDirection.x * 4, _movementDirection.y);
                _reverse = true;
            }
        }
    }
}