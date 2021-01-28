using System;
using Scenes;
using UnityEngine;

namespace Vehicle {
    public class VehicleController : MonoBehaviour {
        [SerializeField] private GameObject explosionEffect;
        
        private LevelController _levelController;
        private void Start() {
            _levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        }

        public void PlayerDeath() {
            // @ TODO add bonus for first run
            gameObject.SetActive(false);
            var explosionEffectObject = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosionEffectObject, 3f);
            _levelController.SetCurrentLevel();

            _levelController.GameOverHandler();
            // TODO better animation
            // https://trello.com/c/VqNCDMnx/118-p-lepsza-animacja-%C5%9Bmierci-gracza
        }
    }
}