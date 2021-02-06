#pragma warning disable 649

using Projectiles.Player;
using ScriptableObjects.Keyboard;
using ScriptableObjects.Projectile;
using UnityEngine;
using UnityEngine.UIElements;

namespace Vehicle {
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

        [SerializeField] private KeyboardActionKeyCodeSO keyboardControl;

        private bool _blockShooting;
        private KeyboardActionKeyCodeSO _keboardControl;

        public void VehicleInMenu() {
            _blockShooting = true;
            Debug.Log("Vehicle shooting blocked.");
        }

        private void Start() {
            Debug.Log(gameObject.name);
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
            var initialPosition = firePointVertical.position;
            var verticalBullet = Instantiate(Resources.Load("Prefabs/Vertical_Vehicle_Bullet", typeof(GameObject))) as GameObject;
            if (verticalBullet is null) return;
            
            verticalBullet.transform.position = initialPosition;
            verticalBullet.GetComponent<VerticalBullet>().firePointVertical = firePointVertical;
            Destroy(verticalBullet, verticalDistanceRange.projectileDistance);
        }

        private void HorizontalShoot() {
            var initialPosition = firePointHorizon.position;
            var horizontalBullet = Instantiate(Resources.Load("Prefabs/Horizontal_Vehicle_Bullet", typeof(GameObject))) as GameObject;
            if (horizontalBullet is null) return;
            
            horizontalBullet.transform.position = initialPosition;
            
            Destroy(horizontalBullet, horizonDistanceRange.projectileDistance);
        }
    }
}