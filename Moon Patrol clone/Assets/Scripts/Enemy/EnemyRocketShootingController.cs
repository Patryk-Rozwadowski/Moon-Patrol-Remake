using Score;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy {
    public class EnemyRocketShootingController : MonoBehaviour {
        [SerializeField] private GameObject enemyBulletRocket;
        [SerializeField] private GameObject firepoint;

        private GameObject _firepointTransform;
        private ScoreManager _scoreManager;

        // Chance % treshold for ufo shooting
        private float _rocketShootTreshold = 40;

        // Chances % that ufo will shoot with rocket
        private float _rocketShootChance;

        // Random time when ufo can shoot with rocket
        private float _randomTime;

        // Minimal and maximal time between ufo can shoot
        private float _minTime = 2f, _maxTime = 8f;

        private bool _rocketLaunched = false;

        void Start() {
            _scoreManager = GetComponent<ScoreManager>();
            _rocketShootChance = Random.Range(0, 1f);
            _rocketShootChance = Mathf.Round(_rocketShootChance * 100);

            _randomTime = Random.Range(_minTime, _maxTime);
            _randomTime = Mathf.Round(_randomTime);

            Debug.Log($"Treshold for shoot chance {_rocketShootTreshold}% " +
                      $"Shoot chance: {_rocketShootChance}%. " +
                      $"{(_rocketShootTreshold < _rocketShootChance ? $"Rocket will be launch in {_randomTime}" : "Rocket will be not launched.")}");
        }

        void Update() {
            if (!(_rocketShootTreshold < _rocketShootChance) || _rocketLaunched) return;
            if (!(Time.time > _randomTime) || _rocketLaunched) return;
            _rocketLaunched = true;
            Debug.Log($"{gameObject.name} launched rocket.");
            Instantiate(enemyBulletRocket, firepoint.transform.position, Quaternion.identity);
        }
    }
}