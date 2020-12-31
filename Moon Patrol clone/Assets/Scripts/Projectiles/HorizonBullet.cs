using UnityEngine;

public class HorizonBullet : MonoBehaviour {
    [SerializeField] private float speed = 20f;
    [SerializeField] private Transform firePointHorizon;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform vehicleAngle;

    private GameObject _bullet;
    private void Start() {
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        Debug.Log($"Vertical Bullet hit: {obj.name}");
    }
}