using UnityEngine;

public class VerticalBullet : MonoBehaviour {
    [SerializeField] private Transform firePointVertical;
    [SerializeField] public Rigidbody2D bulletRigidBody;
    [SerializeField] private ProjectileSO projectileData;
    private void Start() {
        bulletRigidBody.velocity = new Vector2(firePointVertical.transform.position.x, projectileData.speed);
    }

    private void Update() {
        bulletRigidBody.position = new Vector2(firePointVertical.position.x, bulletRigidBody.position.y + projectileData.speed);
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        Debug.Log($"Vertical Bullet hit: {obj.name}");
    }
}