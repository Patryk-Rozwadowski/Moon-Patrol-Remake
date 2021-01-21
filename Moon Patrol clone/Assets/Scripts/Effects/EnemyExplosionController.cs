using UnityEngine;

public class EnemyExplosionController : MonoBehaviour {
    [SerializeField] private Sprite explosionEffect;
    private void Start() {
        Instantiate(explosionEffect);
        Destroy(gameObject, 0.5f);
    }
}