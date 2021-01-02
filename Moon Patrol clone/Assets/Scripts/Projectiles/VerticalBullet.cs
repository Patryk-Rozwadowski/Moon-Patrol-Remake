using System;
using UnityEngine;

public class VerticalBullet : MonoBehaviour {
    [SerializeField] private Transform firePointVertical;
    [SerializeField] public Rigidbody2D bulletRigidBody;
    [SerializeField] private ProjectileSpeedSO projectileSpeed;
    private void Start() {
        bulletRigidBody.velocity = new Vector2(firePointVertical.transform.position.x, projectileSpeed.projectileSpeed);
    }

    private void Update() {
        bulletRigidBody.position = new Vector2(firePointVertical.position.x, bulletRigidBody.position.y + projectileSpeed.projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        Debug.Log($"Vertical Bullet hit: {obj.name}");
    }

    private void OnDestroy() {
        Debug.Log($"{gameObject.name} Destroyed");
    }
}