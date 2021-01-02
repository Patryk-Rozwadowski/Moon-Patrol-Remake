using UnityEngine;

public class IsVehicleInAir : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        VehicleController.isInAir = false;
        Debug.Log("Tire on ground");
    }

    private void OnTriggerExit2D(Collider2D other) {
        VehicleController.isInAir = true;
        Debug.Log("Tire in air");
    }
}