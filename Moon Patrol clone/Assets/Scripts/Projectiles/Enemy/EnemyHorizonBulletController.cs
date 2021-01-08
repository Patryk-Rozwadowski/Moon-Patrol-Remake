using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizonBulletController : MonoBehaviour {
    [SerializeField] private Rigidbody2D bulletRigidBody = null;
    [SerializeField] private ProjectileSpeedSO projectileSpeed = null;

    private void Start() {
        bulletRigidBody.velocity = new Vector2(projectileSpeed.projectileSpeed, 0);
    }

    private void OnDestroy() {
        Debug.Log($"{gameObject.name} Destroyed");
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        Destroy(gameObject);
        VehicleController player = obj.GetComponent<VehicleController>();
        Debug.Log($"Enemy hit: {obj} ");
        if (player == null) return;
        player.PlayerDeath();
        Debug.Log($"Vertical Bullet hit: {obj.name}");
    }
}