#pragma warning disable 649
using Projectiles;
using Projectiles.Player;
using Score;
using ScriptableObjects.Obstacles;
using UnityEngine;

namespace Obstacles {
    public class ScoreJumpOverController : MonoBehaviour {
        [SerializeField] private ObstaclesParamsSO obstacleParamsScriptableObject;
        [SerializeField] private Collider2D jumpOverCollider2D;
    
        private ScoreManager _scoreManager;
        private bool isColliderIsUntouched = true;
        private void Start() {
            _scoreManager = gameObject.GetComponent<ScoreManager>();
            Debug.Log(_scoreManager);
        }

        private void OnTriggerEnter2D(Collider2D obj) {
            HorizonBullet horizonBullet = obj.GetComponent<HorizonBullet>();
            if (horizonBullet == true) return;
            if (isColliderIsUntouched == true) {
                Debug.Log($"Score jump over: {obstacleParamsScriptableObject.jumpOverScore}");
                _scoreManager.AddOverallPlayerScore(obstacleParamsScriptableObject.jumpOverScore);
                isColliderIsUntouched = false;
            }

        }
    }
}
