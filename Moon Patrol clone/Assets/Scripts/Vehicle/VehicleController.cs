using UnityEngine;

namespace Vehicle {
    public class VehicleController : MonoBehaviour {
        public void PlayerDeath() {
            // @ TODO add bonus for first run
            gameObject.SetActive(false);
            
            // TODO better animation
            // https://trello.com/c/VqNCDMnx/118-p-lepsza-animacja-%C5%9Bmierci-gracza
        }
    }
}