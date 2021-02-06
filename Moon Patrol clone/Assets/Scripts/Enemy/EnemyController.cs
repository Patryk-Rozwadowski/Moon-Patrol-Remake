#pragma warning disable 649

using Score;
using ScriptableObjects.Enemies;
using UnityEngine;

namespace Enemy {
    public class EnemyController : MonoBehaviour {
        [SerializeField] private GameObject explosionEffect;
        [SerializeField] private Transform pfScorePopup;
        [SerializeField] private EnemyParamsSO enemyParamsSO;

        private const float ExplosionEffectLifeTime = 4f;
        
        private ScoreManager _scoreManager;
        private EnemyAI _enemyAi;
        private AudioManager _audioManager;
        
        private bool _isplayerPosNull, _fleeing;
        private float _spawnedTime, _timeToFlee, _respawnTime;
        
        public void EnemyDeath() {
            _scoreManager.AddOverallPlayerScore(enemyParamsSO.score);
            RenderExplosionAndDestroy();
        }
        
        private void Start() {
            _audioManager = FindObjectOfType<AudioManager>();
            _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            _enemyAi = gameObject.GetComponent<EnemyAI>();
            _timeToFlee = enemyParamsSO.timeToFlee;
            _respawnTime = 0;
        }

        private void Update() {
            _respawnTime += Time.deltaTime;
            if (!(_respawnTime > _timeToFlee) || _fleeing) return;
            _fleeing = true;
            _enemyAi.EnemyFlee();
            Debug.Log($"{gameObject.name} is fleeing!");
        }

        private void RenderExplosionAndDestroy() {
            var explosionEffectGO = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            var aiWalls = GameObject.Find("AiWalls").transform;
            explosionEffectGO.transform.parent = aiWalls;
            _audioManager.Play("Hit");
            
            Destroy(explosionEffectGO, ExplosionEffectLifeTime);
            Destroy(gameObject);
        }
    }
}