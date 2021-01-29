#pragma warning disable 649

using ScriptableObjects.Keyboard;
using ScriptableObjects.Projectile;
using UnityEngine;

namespace Vehicle {
    public class VehicleWeaponController : MonoBehaviour {
        [SerializeField] private Transform
            firePointHorizon,
            firePointVertical;

        [SerializeField] private GameObject
            bulletVertical,
            bulletHorizon,

        [SerializeField] private ProjectileDistanceSO
            horizonDistanceRange,
            verticalDistanceRange;

        [SerializeField] private KeyboardActionKeyCodeSO keyboardControl;

        private bool _blockShooting = false;
        private KeyboardActionKeyCodeSO _keboardControl;

        public void VehicleInMenu() {
            _blockShooting = true;
            Debug.Log("Vehicle shooting blocked.");
        }

        private void Start() {
            _keboardControl = keyboardControl;
        }

        private void Update() {
            if (_blockShooting) return;
            Shoot();

            if (Input.GetKey("escape")) Application.Quit();
        }

        private void Shoot() {
            if (!Input.GetKeyDown(_keboardControl.shoot)) return;
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
}