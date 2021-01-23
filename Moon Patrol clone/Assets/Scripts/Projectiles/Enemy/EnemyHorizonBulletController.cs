#pragma warning disable 649

using ScriptableObjects.Projectile;
using UnityEngine;
using Vehicle;

namespace Projectiles.Enemy {
    public class EnemyHorizonBulletController : MonoBehaviour {
        [SerializeField] private Rigidbody2D bulletRigidBody;
        [SerializeField] private ProjectileSpeedSO projectileSpeed;

        private void Start() {
            bulletRigidBody.velocity = new Vector2(projectileSpeed.projectileSpeed, 0);
        }

        private void OnDestroy() {
            Debug.Log($"{gameObject.name} Destroyed");
        }

        private void OnTriggerEnter2D(Collider2D obj) {
            Destroy(gameObject);
            var player = obj.GetComponent<VehicleController>();
            Debug.Log($"Enemy hit: {obj} ");
            if (player == null) return;
            player.PlayerDeath();
            Debug.Log($"Vertical Bullet hit: {obj.name}");
        }
    }
}