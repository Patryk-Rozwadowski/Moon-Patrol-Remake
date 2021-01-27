using Scenes;
using UnityEngine;
using Vehicle;

namespace Checkpoints {
    public class CheckPoint : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            var vehicle = other.GetComponent<VehicleController>();
            if (vehicle != null) {
                var sceneController = GameObject.Find("LevelController").GetComponent<LevelController>();
                Debug.Log("next level");
                sceneController.NextLevelHandler();
            }
        }
    }
}