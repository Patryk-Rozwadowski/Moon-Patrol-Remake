using System;
using UnityEngine;

namespace Vehicle {
    public class VehicleController : MonoBehaviour {
        private LevelController _levelController;
        private void Start() {
            _levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        }

        public void PlayerDeath() {
            // @ TODO add bonus for first run
            gameObject.SetActive(false);
            _levelController.RestartLevel();
            
            // TODO better animation
            // https://trello.com/c/VqNCDMnx/118-p-lepsza-animacja-%C5%9Bmierci-gracza
        }
    }
}