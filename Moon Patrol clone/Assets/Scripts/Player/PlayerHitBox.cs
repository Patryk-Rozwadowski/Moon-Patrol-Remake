using UnityEngine;

namespace Player {
    public class PlayerHitBox : MonoBehaviour {
        public void PlayerDeath() {
            Destroy(gameObject);
            Debug.LogWarning("Player death");
        }
    }
}