using UnityEngine;

public class ObstaclesController : MonoBehaviour {
    [SerializeField] private Collider2D obstacleCollider2D;

    private void OnTriggerEnter2D(Collider2D obj) {
        var player = obj.GetComponent<VehicleController>();
        Debug.Log($"Enemy hit: {obj} ");
        if (player == null) return;
        player.PlayerDeath();
        Debug.Log(obj.name);
        Debug.Log("player dead");
    }
}