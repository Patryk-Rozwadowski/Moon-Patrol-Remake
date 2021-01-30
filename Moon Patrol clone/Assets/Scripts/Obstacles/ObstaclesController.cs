using UnityEngine;
using Vehicle;

namespace Obstacles {
    public class ObstaclesController : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            var vehicle = other.GetComponent<VehicleTireController>();
            if (vehicle == null) return;
            var vehicleController = other.GetComponent<VehicleTireController>().GetComponentInParent<VehicleController>();
            vehicleController.PlayerDeath();
            Debug.Log($"MINE EXPLOSION ${gameObject.name}");
        }
    }
}