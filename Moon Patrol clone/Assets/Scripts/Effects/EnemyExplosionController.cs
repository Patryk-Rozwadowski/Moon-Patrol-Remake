using UnityEngine;

public class EnemyExplosionController : MonoBehaviour {
    private void Start() {
        Destroy(gameObject, 0.5f);
    }
}