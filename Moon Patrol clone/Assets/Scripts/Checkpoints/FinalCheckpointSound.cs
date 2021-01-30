using UnityEngine;
using Vehicle;

namespace Checkpoints {
    public class FinalCheckpointSound : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D obj) {
            VehicleController vehicle = obj.GetComponent<VehicleController>();
            if (vehicle != null) {
                FindObjectOfType<AudioManager>().Play("LastPoint");
            }
        }
    }
}