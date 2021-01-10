using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleTireController : MonoBehaviour {
    [SerializeField] private Rigidbody2D tireRigidbody2D = null;
    void Update() {
        float pos = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down)).collider.transform.position.y;
        tireRigidbody2D.velocity = tireRigidbody2D.velocity.normalized + new Vector2(10f, pos);
    }
}