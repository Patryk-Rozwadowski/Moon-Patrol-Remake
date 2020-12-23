using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {
    [SerializeField] Rigidbody2D backTire;
    [SerializeField] Rigidbody2D frontTire;

    [SerializeField] private float speed = 200;
    private float movement;

    private void Start() {
    }

    
    
    void Update() {
        movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        backTire.AddTorque(-speed * Time.fixedDeltaTime);
    }
}
