using UnityEngine;

public class ObstaclesController : MonoBehaviour {
    [SerializeField] private Collider2D obstacleCollider2D;
    
    private void OnTriggerEnter2D(Collider2D obj) {
        VehicleController player = obj.GetComponent<VehicleController>();
        if (player == null) return;
        player.PlayerDeath();
    }
}