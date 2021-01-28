#pragma warning disable 649

using Score;
using ScriptableObjects.Obstacles;
using UnityEngine;
using Vehicle;

namespace Obstacles {
    public class ScoreJumpOverController : MonoBehaviour {
        [SerializeField] private ObstaclesParamsSO obstacleParamsScriptableObject;
        [SerializeField] private Collider2D jumpOverCollider2D;
    
        private ScoreManager _scoreManager;
        private bool isColliderIsUntouched = true;
        private void Start() {
            _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        }

        private void OnTriggerEnter2D(Collider2D obj) {
            Debug.LogWarning($"HOLE HIT {obj.name}");
            VehicleController vehicle = obj.GetComponent<VehicleController>();
            if (vehicle != null) {
                Debug.Log($"Score jump over: {obstacleParamsScriptableObject.jumpOverScore}");
                _scoreManager.AddOverallPlayerScore(obstacleParamsScriptableObject.jumpOverScore);
                isColliderIsUntouched = false;
            };
        }
    }
}
