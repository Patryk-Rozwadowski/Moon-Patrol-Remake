using UnityEngine;
using Vehicle;

namespace Obstacles {
    public class ObstaclesController : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            var objectName = other.name;
            // TODO take tires instead name
            if (objectName == "Vehicle Hitbox") {
                var vehicleController = other.GetComponent<BoxCollider2D>().GetComponentInParent<VehicleController>();
                vehicleController.PlayerDeath();
                Debug.Log("Destroyed by mine.");
            }
        }
    }
}