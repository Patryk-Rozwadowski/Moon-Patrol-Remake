using Projectiles.Player;
using UnityEngine;
using Vehicle;

namespace Projectiles.Enemy {
    public class EnemyProjectileCollisionController : MonoBehaviour {
        [SerializeField] private GameObject explosionEffect;
        [SerializeField] private GameObject holeGameObject;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Ground")) {
                var explosionPosition = transform.position;
                var explosionEffectObject = Instantiate(explosionEffect, explosionPosition, Quaternion.identity);
                
                if(holeGameObject != null) Instantiate(holeGameObject, explosionPosition, Quaternion.identity);
                Destroy(gameObject);
                Destroy(explosionEffectObject, 0.2f);
            }

            var playerVehicle = other.GetComponent<VehicleController>();
            if (playerVehicle != null) playerVehicle.PlayerDeath();

            var playerVerticalBullet = other.GetComponent<VerticalBullet>();
            if (playerVerticalBullet != null) {
                Destroy(gameObject);
            }
            // TODO --player life
        }
    }
}