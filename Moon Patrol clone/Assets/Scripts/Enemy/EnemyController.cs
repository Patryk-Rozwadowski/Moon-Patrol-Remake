#pragma warning disable 649

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
        private readonly float fireRate = 0.5f;
        private float nextFire;
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

        private void Update() {
            if (_isplayerPosNull) return;
            if (playerPos.position.x < enemyParams.visionRange && Time.time > nextFire) Shooting();
        }

        // FOR TANK
        private void Shooting() {
            nextFire = Time.time + fireRate;
            Instantiate(enemyHorizontalBullet, firepoint.position, Quaternion.identity);
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
            RenderExplosionAndDestroy();
        }
        
        private void RenderExplosionAndDestroy() {
            GameObject explosionEffectGO = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosionEffectGO, ExplosionEffectLifeTime);
            Destroy(gameObject);
        }
    }
}