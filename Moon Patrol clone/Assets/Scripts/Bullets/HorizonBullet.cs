using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizonBullet : MonoBehaviour {
    [SerializeField] private float speed = 20f;
    public Rigidbody2D rb;

    private void Start() {
        rb.velocity = transform.right * speed;
        Debug.Log("Horizon bullet");
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        Debug.Log($"Horizon Bullet hit: {obj.name}");
        // Destroy(gameObject);
    }
}