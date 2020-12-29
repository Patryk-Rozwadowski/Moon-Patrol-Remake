using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleWeapon : MonoBehaviour {
    public Transform firePointHorizon;
    public Transform firePointVertical;
    
    [SerializeField] private KeyCode horizonFireKey = KeyCode.None;
    [SerializeField] private KeyCode verticalFireKey = KeyCode.None;

    [SerializeField] private GameObject bulletVertical;
    [SerializeField] private GameObject bulletHorizon;
    void Update() {
        if (Input.GetKeyDown(horizonFireKey)) {
            HorizontalShoot();
        } else if (Input.GetKeyDown(verticalFireKey)) {
            VerticalShoot();
        }
    }

    private void HorizontalShoot() {
        Instantiate(bulletHorizon, firePointHorizon.position, firePointHorizon.rotation);
        Debug.Log("Horizontal shoot");
    }

    private void VerticalShoot() {
        Instantiate(bulletVertical, firePointVertical.position, firePointVertical.rotation);
        Debug.Log("Vertical shoot");
    }
}