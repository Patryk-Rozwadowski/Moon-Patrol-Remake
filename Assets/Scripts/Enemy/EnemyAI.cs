using UnityEngine;

namespace Enemy {
    [RequireComponent(typeof(PolygonCollider2D))]
    [DisallowMultipleComponent]
    public class EnemyAI : MonoBehaviour {
        // TODO take from enemyParamsSO
        private float _characterVelocity = 5f;

        private readonly float _directionChangeTime = 2f;

        private float _latestDirectionChangeTime;
        private bool _moveDownAtStart = true;

        private Vector2 _movementDirection;
        private Vector2 _movementPerSecond;

        private bool _reverse, _flee;

        public void EnemyFlee() {
            _flee = true;
            _characterVelocity = 15f;
            _movementDirection = new Vector2(Random.Range(-1f, 1f), 1f);
        }

        private void Start() {
            _latestDirectionChangeTime = 0f;
            CalcuateNewMovementVector();
        }

        private void Update() {
            var position = transform.position;
            position = new Vector2(position.x + _movementPerSecond.x * Time.deltaTime,
                position.y + _movementPerSecond.y * Time.deltaTime);
            transform.position = position;
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

        private void CalcuateNewMovementVector() {
            if (_moveDownAtStart) {
                _movementDirection = new Vector2(Random.Range(-1f, 1f), -1f);
                _movementPerSecond = new Vector2(_movementDirection.x * _characterVelocity, _movementDirection.y);
                _moveDownAtStart = false;
                _latestDirectionChangeTime = Time.time;
                return;
            }

            _movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _movementPerSecond = new Vector2(_movementDirection.x * _characterVelocity, _movementDirection.y);
        }
    }
}