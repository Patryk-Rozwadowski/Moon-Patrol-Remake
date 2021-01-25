using UnityEngine;

namespace Player {
    public class PlayerHitBox : MonoBehaviour {
        public void PlayerDeath() {
            //FindObjectOfType<AudioManager>().Play("Crash"); coś tu nie działa
            Destroy(gameObject);
            Debug.LogWarning("Player death");
        }
    }
}