using Enemy;
using ScriptableObjects.Projectile;
using UnityEngine;

namespace Projectiles.Player {
    public class VerticalBullet : MonoBehaviour {
        [SerializeField] public Transform firePointVertical;
        [SerializeField] public Rigidbody2D bulletRigidBody;
        [SerializeField] public ProjectileSpeedSO projectileSpeed;

        private void Start() {
            BulletFired();
            FindObjectOfType<AudioManager>().Play("Blaster");
        }

        private void Update() {
            MoveBulletVertically();
        }

        private void BulletFired() {
            bulletRigidBody.velocity =
                new Vector2(firePointVertical.transform.position.x, projectileSpeed.projectileSpeed);
        }

        private void MoveBulletVertically() {
            bulletRigidBody.position = new Vector2(firePointVertical.position.x,
                bulletRigidBody.position.y + projectileSpeed.projectileSpeed);
        }

        private void OnDestroy() {
            Debug.Log($"{gameObject.name} Destroyed");
        }

        private void OnTriggerEnter2D(Collider2D obj) {
            var enemy = obj.GetComponent<EnemyController>();
            if (enemy != null) {
                enemy.EnemyDeath();
                Destroy(gameObject);
            }
        }
    }
}