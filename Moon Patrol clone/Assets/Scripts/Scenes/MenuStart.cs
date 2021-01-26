using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Keyboard;
using UnityEngine;
using Vehicle;

public class MenuStart : MonoBehaviour {
    [SerializeField] private KeyboardActionKeyCode keyboardActionKeyCodes;

    private KeyCode _startKey;
    void Start() {
        _startKey = keyboardActionKeyCodes.start;

        var vehicleShootingController = GameObject.Find("Weapon").GetComponent<VehicleWeaponController>();
        vehicleShootingController.VehicleInMenu();
    }
    void Update() {
        if (Input.GetKeyDown(_startKey)) {
            Debug.Log("Start level");
        }
    }
}