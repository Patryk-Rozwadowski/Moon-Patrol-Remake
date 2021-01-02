using UnityEngine;

public class IsVehicleInAir : MonoBehaviour {
    private void Start() {
        Debug.Log("Collider");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        VehicleController.isInAir = false;
        Debug.Log(other.name);
        Debug.Log("Tire on ground");
    }

    private void OnTriggerExit2D(Collider2D other) {
        VehicleController.isInAir = true;
        Debug.Log("Tire in air");
    }
}