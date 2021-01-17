using UnityEngine;

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
        Destroy(gameObject);
        var enemy = obj.GetComponent<EnemyController>();
        if (enemy == null) return;
        enemy.EnemyDeath();
    }
}