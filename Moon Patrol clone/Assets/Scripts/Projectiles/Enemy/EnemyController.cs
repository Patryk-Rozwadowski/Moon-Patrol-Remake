#pragma warning disable 649
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private Transform firepoint;
    [SerializeField] private Transform playerPos;
    [SerializeField] private EnemyParamsSO enemyParams;
    [SerializeField] private GameObject enemyHorizontalBullet;

    private readonly float fireRate = 0.5f;
    private float nextFire;

    private void Start() {
        Debug.Log($"Enemy vision: {enemyParams.visionRange}");
    }

    private void Update() {
        if (playerPos == null) return;
        if (playerPos.position.x < enemyParams.visionRange && Time.time > nextFire) Shooting();
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