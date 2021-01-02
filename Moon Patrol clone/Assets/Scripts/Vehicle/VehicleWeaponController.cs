using UnityEngine;

public class VehicleWeaponController : MonoBehaviour {
    [SerializeField] private Transform firePointHorizon;
    [SerializeField] private Transform firePointVertical;

    [SerializeField] private GameObject bulletVertical;
    [SerializeField] private GameObject bulletHorizon;

    [SerializeField] private ProjectileDistanceSO horizonDistanceRange;
    [SerializeField] private ProjectileDistanceSO verticalDistanceRange;

    [SerializeField] private KeyboardActionKeyCode keyboardControl;

    private void Update() {
        Shoot();
    }

    private void Shoot() {
        if (Input.GetKeyDown(keyboardControl.horizontalShoot))
            HorizontalShoot();
        else if (Input.GetKeyDown(keyboardControl.verticalShoot)) VerticalShoot();
    }

    private void VerticalShoot() {
        var bullet = Instantiate(bulletVertical, firePointVertical.position, Quaternion.identity);
        Destroy(bullet, verticalDistanceRange.projectileDistance);
    }

    private void HorizontalShoot() {
        var bullet = Instantiate(bulletHorizon, firePointHorizon.position, Quaternion.identity);
        Destroy(bullet, horizonDistanceRange.projectileDistance);
    }
}