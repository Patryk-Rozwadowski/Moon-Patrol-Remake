#pragma warning disable 649

using Enemy;
using Obstacles;
using ScriptableObjects.Projectile;
using UnityEngine;

namespace Projectiles.Player {
    public class HorizonBullet : MonoBehaviour {
        [SerializeField] private Rigidbody2D bulletRigidBody;
        [SerializeField] private ProjectileSpeedSO projectileSpeed;

        private void Start() {
            bulletRigidBody.velocity = new Vector2(projectileSpeed.projectileSpeed, 0);
        }

        private void OnDestroy() {
            Debug.Log($"{gameObject.name} Destroyed");
        }

        private void OnTriggerEnter2D(Collider2D obj) {
            EnemyController enemy = obj.GetComponent<EnemyController>();
            if (enemy != null) enemy.EnemyDeath();

            StoneController stone = obj.GetComponent<StoneController>();
            if (stone != null) {
                stone.Destroy();
                Destroy(gameObject);
            }

            Debug.Log($"Vertical Bullet hit: {obj.name}");
        }
    }
}