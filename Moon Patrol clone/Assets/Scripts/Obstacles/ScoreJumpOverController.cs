#pragma warning disable 649

using Score;
using ScriptableObjects.Obstacles;
using UnityEngine;
using Vehicle;

namespace Obstacles {
    public class ScoreJumpOverController : MonoBehaviour {
        [SerializeField] private ObstaclesParamsSO obstacleParamsScriptableObject;

        private bool _isColliderIsUntouched = true;
        private ScoreManager _scoreManager;

        private void Start() {
            _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        }

        private void OnTriggerEnter2D(Collider2D obj) {
            var vehicle = obj.GetComponent<VehicleController>();
            if (vehicle != null) {
                _isColliderIsUntouched = false;
                Debug.Log($"Score jump over: {obstacleParamsScriptableObject.jumpOverScore}");
                _scoreManager.AddOverallPlayerScore(obstacleParamsScriptableObject.jumpOverScore);
            };
        }
    }
}
