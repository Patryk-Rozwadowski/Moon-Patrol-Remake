using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleTireController : MonoBehaviour {
    [SerializeField] private Rigidbody2D tireRigidbody2D = null;
    
    private bool jumping = false;
    private float jumpTime = 1.5f;
    private float nextJump = 0f;
    private float pos = 0f;
    private void Start() {
        pos = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down)).collider.transform.position.y;
    }

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.D) && nextJump < jumpTime) {
            nextJump = Time.time + 2;
        }
        
        if ( Time.time < nextJump) {
            tireRigidbody2D.velocity = new Vector2(5f, 1f);
            Debug.Log($"Jumtime in jump: {nextJump}");
        }
        else {
            if (nextJump != 0 && nextJump >= jumpTime) {
                nextJump -= Time.time;
                Debug.Log($"MORE THAN JUMPTIME {nextJump}");
            }
            
            Debug.Log(nextJump);
            tireRigidbody2D.velocity = new Vector2(10f, pos);
            
            // Debug.Log(pos);
        }

    }
}