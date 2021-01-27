﻿using ScriptableObjects.Keyboard;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vehicle;

namespace Scenes {
    public class MenuStart : MonoBehaviour {
        [SerializeField] private KeyboardActionKeyCode keyboardActionKeyCodes;

        private KeyCode _startKey;
        private LevelController _levelController;
        
        void Start() {
            _startKey = keyboardActionKeyCodes.start;
            _levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
            var vehicleShootingController = GameObject.Find("Weapon").GetComponent<VehicleWeaponController>();
            vehicleShootingController.VehicleInMenu();
        }

        void Update() {
            if (Input.GetKeyDown(_startKey)) {
                _levelController.StartGame();
            }
        }
    }
}