using Enemy;
using UnityEngine;
using UnityEngine.U2D;
using Vehicle;

namespace Projectiles.Enemy {
    public class EnemyVerticalRocketController : MonoBehaviour {
        [SerializeField] private GameObject explosionEffect;
        
        private Rigidbody2D rb2D;
        private float thrust = 2;

        void Start() {
            rb2D = gameObject.GetComponent<Rigidbody2D>();
        }

        private void Update() {
            rb2D.AddForce(transform.right * thrust);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            var ground = other.GetComponent<SpriteShapeController>();
            if (ground != null) {
                var explosionEffectObject = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(explosionEffectObject, 0.2f);
                Destroy(gameObject);
            }

            var playerVehicle = other.GetComponent<VehicleController>();
            if(playerVehicle != null) playerVehicle.PlayerDeath();
            
            // TODO --player life
        }
    }
}