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
    
    [SerializeField] private float verticalDistance;
    [SerializeField] private float horizonDistance;
    
    void Update() {
        if (Input.GetKeyDown(horizonFireKey)) {
            HorizontalShoot();
        } else if (Input.GetKeyDown(verticalFireKey)) {
            VerticalShoot();
        }
    }

    private void HorizontalShoot() {
        // GameObject bullet = Instantiate(bulletHorizon, firePointHorizon.position, firePointHorizon.rotation);
        // Destroy(bullet, verticalDistance);
        ScriptableObject.CreateInstance<pf>();
        Debug.Log("Horizontal shoot");
    }

    private void VerticalShoot() {
        
        GameObject bullet = Instantiate(bulletVertical, firePointVertical.position, firePointVertical.rotation);
        // Destroy(bullet, horizonDistance);
        Debug.Log("Vertical shoot");
    }
}