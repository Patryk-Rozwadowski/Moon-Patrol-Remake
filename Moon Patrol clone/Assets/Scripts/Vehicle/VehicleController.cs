using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {
    [SerializeField] Rigidbody2D backTire;
    [SerializeField] private float speed = 200;
    [SerializeField] private Rigidbody2D rb;
    public static bool isInAir {
        get;
        set;
    }

    void Update() {
        // float distance = Vector3.Distance (object1.transform.position, object2.transform.position);

        if (Input.GetKeyDown(KeyCode.D)) {
            rb.AddForce(Vector2.up * 19f, ForceMode2D.Impulse);
            Debug.Log("Jump");
            
        }

        if (isInAir == true) {
            Debug.LogWarning("IN AIR");
            rb.freezeRotation = true;
        }
        else {
            rb.freezeRotation = false;
            backTire.AddTorque(-speed * Time.fixedDeltaTime);

        }
    }
}