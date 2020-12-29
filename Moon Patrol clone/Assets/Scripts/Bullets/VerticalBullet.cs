using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBullet : MonoBehaviour {

    [SerializeField] private float speed = 20f;
    public Rigidbody2D rb;

    private void Start() {
        rb.velocity = transform.up * speed;
        Debug.Log("Vertical bullet");
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        Debug.Log($"Vertical Bullet hit: {obj.name}");
        Destroy(gameObject);
    }
}