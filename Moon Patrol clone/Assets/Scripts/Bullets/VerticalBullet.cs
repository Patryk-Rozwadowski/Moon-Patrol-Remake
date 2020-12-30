using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBullet : MonoBehaviour {

    [SerializeField] private float speed = 20f;
    [SerializeField] private Transform firePointVertical;
    [SerializeField] public Rigidbody2D rb;
    
    private void Start() {
        rb.velocity = new Vector2(rb.transform.position.x, 5);
    }

    private void Update() {
        rb.position = new Vector2(firePointVertical.position.x, rb.position.y);
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        Debug.Log($"Vertical Bullet hit: {obj.name}");
        // Destroy(gameObject);
    }
}