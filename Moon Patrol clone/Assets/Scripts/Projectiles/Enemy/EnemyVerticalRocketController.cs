using UnityEngine;

namespace Projectiles.Enemy {
    public class EnemyVerticalRocketController : MonoBehaviour {
        private Rigidbody2D _rb2D;
        private float thrust = 1f;

        void Start() {
            _rb2D = gameObject.GetComponent<Rigidbody2D>();
        }

        private void Update() {
            _rb2D.AddForce(transform.right * thrust);
        }
    }
}