using UnityEngine;

namespace Vehicle {
    public class VehicleController : MonoBehaviour {
        public void PlayerDeath() {
            // @ TODO add bonus for first run
            gameObject.SetActive(false);
            Debug.LogWarning("Player death");
        }
    }
}