#pragma warning disable 649

using Score;
using ScriptableObjects.Enemies;
using UnityEngine;

namespace Enemy {
    public class EnemyRocketShootingController : MonoBehaviour {
        [SerializeField] private GameObject enemyBulletRocket;
        [SerializeField] private GameObject firepoint;
        [SerializeField] private bool rocket, bomb;
        [SerializeField] private bool color, yellow, blue;

        // TODO change all properties with EnemeyParamsSO
        [SerializeField] private EnemyParamsSO enemyParamsSO;

        private GameObject _firepointTransform;
        private ScoreManager _scoreManager;

        // Chance % treshold for ufo shooting
        private float _rocketShootTreshold = 30;

        // Chances % that ufo will shoot with rocket
        private float _rocketShootChance;

        // Random time when ufo can shoot with rocket
        private float _randomTime;

        // Minimal and maximal time between ufo can shoot
        private float _minTime = 2f, _maxTime = 8f;

        // YELLOW
        private float _attackSpdTimeMinYellow = 2, _attackSpdTimeMaxYellow = 4;

        // COLOR
        private float _attackSpdTimeMinColor = 2, _attackSpdTimeMaxColor = 5;

        // BLUE
        private float _attackSpdTimeMinBlue = 6, _attackSpdTimeMaxBlue = 10;

        private bool _rocketLaunched = false;
        private float _timeToFlee;
        private float _respawnTime;
        void Start() {
            _respawnTime = 0;
            _scoreManager = GetComponent<ScoreManager>();
            _rocketShootChance = Random.Range(0, 1f);
            _randomTime = Random.Range(_minTime, _maxTime);

            _rocketShootChance = Mathf.Round(_rocketShootChance * 100);
            _randomTime = Mathf.Round(_randomTime);
            _timeToFlee = enemyParamsSO.timeToFlee;
            
            if (yellow) _randomTime = Random.Range(_attackSpdTimeMinYellow, _attackSpdTimeMaxYellow);
            if (color) _randomTime = Random.Range(_attackSpdTimeMinColor, _attackSpdTimeMaxColor);
            if (blue) _randomTime = Random.Range(_attackSpdTimeMinBlue, _attackSpdTimeMaxBlue);
            
            var chancesInfo =
                $"Treshold for type {gameObject.name} shoot chance treshold {_rocketShootTreshold}% Shoot chance: {_rocketShootChance}%. " +
                $"{(_rocketShootTreshold < _rocketShootChance ? $"Rocket will be launch in {_randomTime}" : "Rocket will be not launched.")}";

            Debug.Log(chancesInfo);
        }

        void Update() {
            _respawnTime += Time.deltaTime;
            if (!(_rocketShootTreshold < _rocketShootChance) || _rocketLaunched) return;
            if (!(_respawnTime > _randomTime) || _rocketLaunched) return;
            _rocketLaunched = true;
            Debug.Log($"{gameObject.name} launched rocket.");
            Instantiate(enemyBulletRocket, firepoint.transform.position, Quaternion.identity);
        }
    }
}