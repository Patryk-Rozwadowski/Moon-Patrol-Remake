#pragma warning disable 649

using Interfaces;
using UnityEngine;
using Vehicle;

namespace Projectiles.Enemy {
    public class EnemyProjectileCollisionController : MonoBehaviour, IDestroyable {
        [SerializeField] private GameObject explosionEffect;
        [SerializeField] private GameObject holeGameObject;

        public void Destroyed() {
            var explosionEffectGameObject = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosionEffectGameObject, 1f);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Ground")) {
                var explosionPosition = transform.position;
                var explosionEffectObject = Instantiate(explosionEffect, explosionPosition, Quaternion.identity);

                if (holeGameObject != null) Instantiate(holeGameObject, explosionPosition, Quaternion.identity);
                Destroy(gameObject);
                Destroy(explosionEffectObject, 0.2f);
            }

            if (other.CompareTag("Player")) {
                var playerVehicle = other.GetComponentInParent<VehicleController>();
                playerVehicle.PlayerDeath();
            }
        }
    }
}