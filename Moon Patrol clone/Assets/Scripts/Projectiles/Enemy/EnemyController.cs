#pragma warning disable 649

using System;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private Transform firepoint;
    [SerializeField] private Transform playerPos;
    [SerializeField] private EnemyParamsSO enemyParams;
    [SerializeField] private GameObject enemyHorizontalBullet;
    
    private ScoreManager _scoreManager;

    private readonly float fireRate = 0.5f;
    private float nextFire;


    private void Start() {
        _scoreManager = GetComponent<ScoreManager>();
    }

    private void Update() {
        if (playerPos == null) return;
        if (playerPos.position.x < enemyParams.visionRange && Time.time > nextFire) Shooting();
    }

    public void EnemyDeath() {
        Debug.Log($"Enemy death: {enemyParams.score}");
        _scoreManager.AddOverallPlayerScore(enemyParams.score);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Shooting() {
        nextFire = Time.time + fireRate;
        Instantiate(enemyHorizontalBullet, firepoint.position, Quaternion.identity);
    }
}