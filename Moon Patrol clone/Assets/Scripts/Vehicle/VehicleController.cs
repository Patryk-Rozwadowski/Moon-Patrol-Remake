using System;
using UnityEngine;

public class VehicleController : MonoBehaviour {

    public void PlayerDeath() {
        // @ TODO add bonus for first run
        gameObject.SetActive(false);
        Debug.LogWarning("Player death");
    }
}