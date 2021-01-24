using Enemy;
using Obstacles;
using ScriptableObjects.Projectile;
using UnityEngine;

namespace Projectiles {
    public class VerticalBullet : MonoBehaviour {
        [SerializeField] public Transform firePointVertical;
        [SerializeField] public Rigidbody2D bulletRigidBody;
        [SerializeField] public ProjectileSpeedSO projectileSpeed;

        private void Start() {
            bulletRigidBody.velocity = new Vector2(firePointVertical.transform.position.x, projectileSpeed.projectileSpeed);
        }

        private void Update() {
            bulletRigidBody.position = new Vector2(firePointVertical.position.x,
                bulletRigidBody.position.y + projectileSpeed.projectileSpeed);
        }

        private void OnDestroy() {
            Debug.Log($"{gameObject.name} Destroyed");
        }

        private void OnTriggerEnter2D(Collider2D obj) {
            var enemy = obj.GetComponent<EnemyController>();
            var stone = obj.GetComponent<StoneController>();
            if (enemy != null) {
                enemy.EnemyDeath();
                Destroy(gameObject);
            }

            // TODO stone??
            // if (stone != null) {
            //     stone.Destroy();
            //     Destroy(gameObject);
            // }
        }
    }
}