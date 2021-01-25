#pragma warning disable 649

using Enemy.Waves;
using Score;
using ScriptableObjects.Enemies;
using UnityEngine;

namespace Enemy {
    public class EnemyController : MonoBehaviour {
        [SerializeField] private GameObject explosionEffect;
        [SerializeField] private Transform firepoint;
        [SerializeField] private Transform playerPos;
        [SerializeField] private EnemyParamsSO enemyParams;
        [SerializeField] private GameObject enemyHorizontalBullet;

        [SerializeField] private Transform pfScorePopup;

        private const float ExplosionEffectLifeTime = 0.2f;
        
        private ScoreManager _scoreManager;
        private bool _isplayerPosNull;
        
        public void EnemyDeath() {
            SetScoreAndShowScorePopup();
            RenderExplosionAndDestroy();
        }
        
        private void Start() {
            _scoreManager = GetComponent<ScoreManager>();
            _isplayerPosNull = playerPos == null;
            if(_isplayerPosNull) Debug.LogWarning($"{gameObject.name} player position not set.");
        }

        private void SetScoreAndShowScorePopup() {
            _scoreManager.AddOverallPlayerScore(enemyParams.score);
            Transform scorePopupTransform = Instantiate(pfScorePopup, transform.position, Quaternion.identity);
            ScorePopupController scorePopupController = scorePopupTransform.GetComponent<ScorePopupController>();
            scorePopupController.Setup(enemyParams.score);
        }
        
        private void OnTriggerEnter2D(Collider2D obj) {
            var ufoProjectile = obj.GetComponent<CircleCollider2D>();
            if (ufoProjectile != null) return;

            var waveManager = obj.GetComponent<WaveManager>();
            if (waveManager != null) return;

            var waveController = obj.GetComponent<WaveController>();
            if (waveController != null) return;
            
            RenderExplosionAndDestroy();
        }
        
        private void RenderExplosionAndDestroy() {
            GameObject explosionEffectGO = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosionEffectGO, ExplosionEffectLifeTime);
            Destroy(gameObject);
        }
    }
}