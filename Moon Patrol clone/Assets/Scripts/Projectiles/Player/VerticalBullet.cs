﻿#pragma warning disable 649

using Enemy;
using ScriptableObjects.Projectile;
using UnityEngine;

namespace Projectiles.Player {
    public class VerticalBullet : MonoBehaviour {
        public Transform firePointVertical;
        private ProjectileSpeedSO _projectileSpeed;

        private Rigidbody2D _rigidbody2D;

        private void Start() {
            _projectileSpeed = Resources.Load<ProjectileSpeedSO>("ScriptableObjects/VerticalProjectileSpeed");

            gameObject.AddComponent<Rigidbody2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.mass = float.MinValue;
            _rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            _rigidbody2D.isKinematic = true;
            
            BulletFired();
        }

        private void Update() {
            MoveBulletVertically();
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

        private void BulletFired() {
            FindObjectOfType<AudioManager>().Play("Blaster");
            _rigidbody2D.position =
                new Vector2(firePointVertical.transform.position.x,
                    _rigidbody2D.position.y + _projectileSpeed.projectileSpeed * Time.deltaTime);
        }

        private void MoveBulletVertically() {
            var firepointVerticalX = firePointVertical.transform.position.x;
            var verticalSpeedMovement = _rigidbody2D.position.y + _projectileSpeed.projectileSpeed * Time.deltaTime;

            _rigidbody2D.position = new Vector2(firepointVerticalX, verticalSpeedMovement);
        }
    }
}