#pragma warning disable 649

using System;
using Interfaces;
using UnityEngine;
using Vehicle;

namespace Projectiles.Enemy {
    public class EnemyProjectileController : MonoBehaviour, IDestroyable {
        [SerializeField] private GameObject explosionEffect;
        [SerializeField] private GameObject holeGameObject;
        [Range(0, 10)] [SerializeField] private int thrustForce;
        [SerializeField] private bool createHole;

        private Rigidbody2D _rb;
        public void Destroyed() {
            var explosionEffectGameObject = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosionEffectGameObject, 1f);
            Destroy(gameObject);
        }

        private void Start() {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {
            _rb.AddForce(transform.right * thrustForce);    
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Ground")) {
                var explosionPosition = transform.position;
                var explosionEffectObject = Instantiate(explosionEffect, explosionPosition, Quaternion.identity);
                if (createHole) Instantiate(holeGameObject, explosionPosition, Quaternion.identity);
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