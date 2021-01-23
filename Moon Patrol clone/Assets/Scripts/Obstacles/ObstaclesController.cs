using UnityEngine;

public class ObstaclesController : MonoBehaviour {
    [SerializeField] private Collider2D obstacleCollider2D;
    
    private void OnTriggerEnter2D(Collider2D obj) {
        VehicleController player = obj.GetComponent<VehicleController>();
        VerticalBullet playerVerticalBullet = obj.GetComponent<VerticalBullet>();
        // TODO FIX
        if (player != null) player.PlayerDeath();
        if (playerVerticalBullet != null) {
            EnemyExplosionController enemyExplosionController = GetComponent<EnemyExplosionController>();
            Instantiate(enemyExplosionController);
            Destroy(gameObject);
        }
    }
}