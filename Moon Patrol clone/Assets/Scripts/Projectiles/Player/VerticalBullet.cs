#pragma warning disable 649

using Enemy;
using ScriptableObjects.Projectile;
using UnityEngine;

namespace Projectiles.Player {
    public class VerticalBullet : MonoBehaviour {
        
        public Transform firePointVertical;
        
        private Rigidbody2D _rigidbody2D;
        private ProjectileSpeedSO _projectileSpeed;
        private void Start() {
            gameObject.AddComponent<Rigidbody2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _projectileSpeed = Resources.Load<ProjectileSpeedSO>("ScriptableObjects/VerticalProjectileSpeed");
            gameObject.transform.parent = firePointVertical;
            BulletFired();
        }

        private void Update() {
            MoveBulletVertically();
        }

        private void BulletFired() {
            FindObjectOfType<AudioManager>().Play("Blaster");
            _rigidbody2D.position =
                new Vector2(firePointVertical.transform.position.x, _rigidbody2D.position.y + (_projectileSpeed.projectileSpeed * Time.deltaTime));
        }

        private void MoveBulletVertically() {
            _rigidbody2D.position = new Vector2(firePointVertical.transform.position.x,
                _rigidbody2D.position.y + (_projectileSpeed.projectileSpeed * Time.deltaTime));
        }

        private void OnDestroy() {
            Debug.Log($"{gameObject.name} Destroyed");
        }

        private void OnTriggerEnter2D(Collider2D obj) {
            var enemy = obj.GetComponent<EnemyController>();
            if (enemy != null) {
                Destroy(gameObject);
                enemy.EnemyDeath();
            }
        }
    }
}