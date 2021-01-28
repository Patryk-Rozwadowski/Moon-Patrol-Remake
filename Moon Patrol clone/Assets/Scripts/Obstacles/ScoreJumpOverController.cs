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
            Debug.LogWarning(obj.name);
            VehicleController horizonBullet = obj.GetComponent<VehicleController>();
            if (horizonBullet == true) return;
            if (isColliderIsUntouched) {
                Debug.Log($"Score jump over: {obstacleParamsScriptableObject.jumpOverScore}");
                _scoreManager.AddOverallPlayerScore(obstacleParamsScriptableObject.jumpOverScore);
                isColliderIsUntouched = false;
            }

        }
    }
}
