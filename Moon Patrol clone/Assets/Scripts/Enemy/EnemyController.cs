#pragma warning disable 649

using System;
using Enemy.Waves;
using Enemy.WaveS;
using Score;
using ScriptableObjects.Enemies;
using UnityEngine;

namespace Enemy {
    public class EnemyController : MonoBehaviour {
        [SerializeField] private GameObject explosionEffect;
        [SerializeField] private Transform firepoint;
        [SerializeField] private Transform playerPos;
        [SerializeField] private EnemyParamsSO enemyParamsSO;
        [SerializeField] private GameObject enemyHorizontalBullet;

        [SerializeField] private Transform pfScorePopup;

        private const float ExplosionEffectLifeTime = 0.2f;
        
        private ScoreManager _scoreManager;
        private EnemyAI _enemyAi;
        
        private bool _isplayerPosNull, _fleeing;
        private float _spawnedTime, _timeToFlee;
        
        public void EnemyDeath() {
            SetScoreAndShowScorePopup();
            RenderExplosionAndDestroy();
        }
        
        private void Start() {
            _enemyAi = gameObject.GetComponent<EnemyAI>();
            _scoreManager = GetComponent<ScoreManager>();
            _timeToFlee = enemyParamsSO.timeToFlee;
            _isplayerPosNull = playerPos == null;
            
            if(_isplayerPosNull) Debug.LogWarning($"{gameObject.name} player position not set.");
        }

        private void Update() {
            if (Time.time > _timeToFlee && _fleeing == false) {
                _fleeing = true;
                _enemyAi.EnemyFlee();
                Debug.Log($"{gameObject.name} is fleeing!");
            }
        }

        private void SetScoreAndShowScorePopup() {
            _scoreManager.AddOverallPlayerScore(enemyParamsSO.score);
            Transform scorePopupTransform = Instantiate(pfScorePopup, transform.position, Quaternion.identity);
            ScorePopupController scorePopupController = scorePopupTransform.GetComponent<ScorePopupController>();
            scorePopupController.Setup(enemyParamsSO.score);
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
            FindObjectOfType<AudioManager>().Play("Hit");
            Destroy(explosionEffectGO, ExplosionEffectLifeTime);
            Destroy(gameObject);
        }
    }
}