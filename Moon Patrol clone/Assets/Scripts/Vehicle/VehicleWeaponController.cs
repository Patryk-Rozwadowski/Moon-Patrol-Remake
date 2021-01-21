#pragma warning disable 649
using UnityEngine;

public class VehicleWeaponController : MonoBehaviour {
    [SerializeField] private Transform
        firePointHorizon,
        firePointVertical;

    [SerializeField] private GameObject
        bulletVertical,
        bulletHorizon;

    [SerializeField] private ProjectileDistanceSO
        horizonDistanceRange,
        verticalDistanceRange;

    [SerializeField] private KeyboardActionKeyCode keyboardControl;

    private void Update() {
        Shoot();
    }

    private void Shoot() {
        if (!Input.GetKeyDown(keyboardControl.shoot)) return;
        HorizontalShoot();
        VerticalShoot();
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