﻿#pragma warning disable 649

using Score;
using ScriptableObjects.Enemies;
using UnityEngine;

namespace Enemy {
    public class EnemyRocketShootingController : MonoBehaviour {
        [SerializeField] private GameObject enemyProjectile;
        [SerializeField] private bool rocket, bomb;
        [SerializeField] private bool color, yellow, blue;

        // TODO change all properties with EnemeyParamsSO
        [SerializeField] private EnemyParamsSO enemyParamsSO;

        // BLUE
        private readonly float _attackSpdTimeMinBlue = 6;
        private readonly float _attackSpdTimeMaxBlue = 10;

        // COLOR
        private readonly float _attackSpdTimeMinColor = 2;
        private readonly float _attackSpdTimeMaxColor = 5;

        // YELLOW
        private readonly float _attackSpdTimeMinYellow = 2;
        private readonly float _attackSpdTimeMaxYellow = 4;

        private GameObject _firepointTransform;

        // Minimal and maximal time between ufo can shoot
        private readonly float _minTime = 2f;
        private readonly float _maxTime = 8f;

        // Random time when ufo can shoot with rocket
        private float _randomTime;
        private float _respawnTime;

        private bool _rocketLaunched;

        // Chances % that ufo will shoot with rocket
        private float _rocketShootChance;

        // Chance % treshold for ufo shooting
        private readonly float _rocketShootTreshold = 30;
        private ScoreManager _scoreManager;
        private float _timeToFlee;

        private void Start() {
            _respawnTime = 0;
            _scoreManager = GetComponent<ScoreManager>();
            _rocketShootChance = Random.Range(0, 1f);
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

        private void FixedUpdate() {
            _respawnTime += Time.deltaTime;
            if (!(_rocketShootTreshold < _rocketShootChance) || _rocketLaunched) return;
            if (!(_respawnTime > _randomTime) || _rocketLaunched) return;
            _rocketLaunched = true;
            Debug.Log($"{gameObject.name} launched rocket.");
            var firepoint = transform.GetChild(0);
            Instantiate(enemyProjectile, firepoint.transform.position, Quaternion.identity);
        }
    }
}