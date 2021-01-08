using UnityEngine;

public class HorizonBullet : MonoBehaviour {
    [SerializeField] private Rigidbody2D bulletRigidBody = null;
    [SerializeField] private ProjectileSpeedSO projectileSpeed = null;

    private void Start() {
        bulletRigidBody.velocity = new Vector2(projectileSpeed.projectileSpeed, 0);
    }

    private void OnDestroy() {
        Debug.Log($"{gameObject.name} Destroyed");
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        EnemyController enemy = obj.GetComponent<EnemyController>();
        if (enemy == null) return;
        enemy.EnemyDeath();
        Destroy(gameObject);
        Debug.Log($"Vertical Bullet hit: {obj.name}");
    }
}