using Projectiles;
using Projectiles.Player;
using UnityEngine;
using UnityEngine.U2D;
using Vehicle;

public class EnemyProjectileCollisionController : MonoBehaviour {
    [SerializeField] private GameObject explosionEffect;

    private void OnTriggerEnter2D(Collider2D other) {
        var ground = other.GetComponent<SpriteShapeController>();
        if (ground != null) {
            var explosionEffectObject = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosionEffectObject, 0.2f);
            Destroy(gameObject);
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