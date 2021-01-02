using UnityEngine;

public class HorizonBullet : MonoBehaviour {
    [SerializeField] private Rigidbody2D bulletRigidBody;
    [SerializeField] private ProjectileSO projectileData;

    private void Start() {
        bulletRigidBody.velocity = new Vector2( projectileData.speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        Debug.Log($"Vertical Bullet hit: {obj.name}");
    }
}