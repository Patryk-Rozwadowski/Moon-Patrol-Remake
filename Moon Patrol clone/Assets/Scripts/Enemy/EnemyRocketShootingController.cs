using Score;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy {
    public class EnemyRocketShootingController : MonoBehaviour {
        [SerializeField] private GameObject enemyBulletRocket;
        [SerializeField] private GameObject firepoint;
        
        private GameObject _firepointTransform;
        private ScoreManager _scoreManager;

        // Chances % that ufo will shoot with rocket
        private float _rocketShootChance;

        // Random time when ufo can shoot with rocket
        private float _randomTime;
        
        // Minimal and maximal time between ufo can shoot
        private float _minTime = 2f, _maxTime = 6f;
        void Start() {
            _scoreManager = GetComponent<ScoreManager>();
            // Instantiate(enemyBulletRocket, firepoint.transform.position, Quaternion.identity);
            _rocketShootChance = Random.Range(0, 1f);
            _rocketShootChance = Mathf.Round(_rocketShootChance * 100);
            
            _randomTime = Random.Range(_minTime, _maxTime);
            _randomTime = Mathf.Round(_randomTime);
            
            Debug.Log($"Shoot chance: {_rocketShootChance}%. Rocket will be launch in {_randomTime}");
        }
        
        void Update() {
            
        }
    }
}