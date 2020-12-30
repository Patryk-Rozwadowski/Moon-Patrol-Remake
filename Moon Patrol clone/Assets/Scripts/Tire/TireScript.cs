using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireScript : MonoBehaviour {
    private void Start() {
        Debug.Log("Collider");
    }

    private void OnTriggerExit2D(Collider2D other) {
        VehicleController.isInAir = true;
        Debug.Log("Tire in air");
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        VehicleController.isInAir = false;
        Debug.Log(other.name);
        Debug.Log("Tire on ground");
    }
}