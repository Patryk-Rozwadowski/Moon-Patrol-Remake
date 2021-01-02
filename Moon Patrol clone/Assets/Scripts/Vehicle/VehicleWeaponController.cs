using UnityEngine;

public class VehicleWeaponController : MonoBehaviour {
    [SerializeField] private Transform firePointHorizon = null;
    [SerializeField] private Transform firePointVertical = null;
    
    [SerializeField] private GameObject bulletVertical = null;
    [SerializeField] private GameObject bulletHorizon = null;

    [SerializeField] private ProjectileDistanceSO horizonDistanceRange = null;
    [SerializeField] private ProjectileDistanceSO verticalDistanceRange = null;

    [SerializeField] private KeyboardActionKeyCode keyboardControl = null;

    private void Update() {
       Shoot();
    }
    
    private void Shoot() {
        if (Input.GetKeyDown(keyboardControl.horizontalShoot)) {
            HorizontalShoot();
        }
        else if (Input.GetKeyDown(keyboardControl.verticalShoot)) {
            VerticalShoot();
        }
    }
    
    private void VerticalShoot() {
        GameObject bullet = Instantiate(bulletVertical, firePointVertical.position, Quaternion.identity);
        Destroy(bullet, verticalDistanceRange.projectileDistance);
    }

    private void HorizontalShoot() {
        GameObject bullet = Instantiate(bulletHorizon, firePointHorizon.position, Quaternion.identity);
        Destroy(bullet, horizonDistanceRange.projectileDistance);
    }
}