using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public Transform firePoint;
    [SerializeField] KeyCode horizonFireKey = KeyCode.None;
    [SerializeField] KeyCode verticalFireKey = KeyCode.None;

    void Update() {
        if (Input.GetKeyDown(horizonFireKey)) {
            HorizontalShoot();
        } else if (Input.GetKeyDown(verticalFireKey)) {
            VerticalShoot();
        }
    }

    private void HorizontalShoot() {
        Debug.Log("Horizontal shoot");
    }

    private void VerticalShoot() {
        Debug.Log("Vertical shoot");
    }
}