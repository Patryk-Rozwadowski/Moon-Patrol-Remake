#pragma warning disable 649
using UnityEngine;

namespace Effects {
    public class EnemyExplosionController : MonoBehaviour {
        [SerializeField] private GameObject explosionEffect;

        // private void OnTriggerEnter2D(Collider2D other) {
        //     GameObject explosionEffectGO = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        //     Destroy(gameObject);
        //     Destroy(explosionEffectGO, 1);
        // }
    }
}