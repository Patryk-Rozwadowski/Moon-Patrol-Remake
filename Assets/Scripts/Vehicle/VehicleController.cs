#pragma warning disable 649

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
            FindObjectOfType<AudioManager>().Play("Crash");

            gameObject.SetActive(false);
            var explosionEffectObject = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosionEffectObject, 4f);

            _levelController.SetCurrentLevel();
            _levelController.GameOverHandler();
        }
    }
}