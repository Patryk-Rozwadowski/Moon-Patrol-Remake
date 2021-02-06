#pragma warning disable 649

using ScriptableObjects.Keyboard;
using UnityEngine;
using Vehicle;

namespace Scenes {
    public class MenuStart : MonoBehaviour {
        [SerializeField] private KeyboardActionKeyCodeSO keyboardActionKeyCodesSo;
        private LevelController _levelController;

        private KeyCode _startKey;

        private void Start() {
            _startKey = keyboardActionKeyCodesSo.start;
            _levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
            var vehicleShootingController = GameObject.Find("Weapon").GetComponent<VehicleWeaponController>();
            vehicleShootingController.VehicleInMenu();
        }

        private void Update() {
            if (Input.GetKeyDown(_startKey)) _levelController.StartGame();
        }
    }
}