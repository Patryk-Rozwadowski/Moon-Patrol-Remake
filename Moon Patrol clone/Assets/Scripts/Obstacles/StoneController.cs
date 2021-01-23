#pragma warning disable 649
using Score;
using ScriptableObjects.Obstacles;
using UnityEngine;
using Vehicle;

namespace Obstacles {
    public class StoneController : MonoBehaviour {
        [SerializeField] private ObstaclesParamsSO rockParams;
        [SerializeField] private GameObject explosionEffect;

        private void Start() {
            GetComponent<SpriteRenderer>().sprite = rockParams.obstacleSprite;
        }

        public void Destroy() {
            ScoreManager scoreManager = GetComponent<ScoreManager>();
            scoreManager.AddOverallPlayerScore(rockParams.destroyScore);

            if (explosionEffect != null) {
                var explosionEffectGameObject = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                // TODO Global time manager
                Destroy(explosionEffectGameObject, 0.2f);
            } 
            else Debug.LogWarning($"{gameObject.name} missing explosion effect");
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            var vehicleController = other.GetComponent<BoxCollider2D>().GetComponentInParent<VehicleController>();
            if(vehicleController != null) vehicleController.PlayerDeath();
        }
    }
}