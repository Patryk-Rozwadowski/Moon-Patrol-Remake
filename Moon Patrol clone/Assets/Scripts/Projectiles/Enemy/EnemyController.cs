using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private GameObject deathEffect = null;
    [SerializeField] private Transform firepoint = null;
    [SerializeField] private Transform playerPos = null;
    [SerializeField] private EnemyParamsSO enemyParams = null;
    [SerializeField] private GameObject enemyHorizontalBullet = null;

    private float fireRate = 1f;
    private float nextFire = 0f;
    
    private void Start() {
        Debug.Log($"Enemy vision: {enemyParams.visionRange}");
    }
    private void Update() {
        if (playerPos.position.x < enemyParams.visionRange && Time.time > nextFire) { 
            Shooting();
        }
    }
    
    public void EnemyDeath() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        GetComponent<SpriteRenderer>().sprite = enemyParams.sprite;
        Destroy(gameObject);
    }

    private void Shooting() {
        nextFire = Time.time + fireRate;
        Instantiate(enemyHorizontalBullet, firepoint.position, Quaternion.identity);
    }
}