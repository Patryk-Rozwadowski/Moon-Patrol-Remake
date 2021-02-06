using UnityEngine;

// TODO need fix nested class
namespace Projectiles.Enemy {
    public class EnemyVerticalBombController : MonoBehaviour {
        public class EnemyVerticalRocketController : MonoBehaviour {
            private Rigidbody2D _rb2D;
            private readonly float thrust = 1;

            private void Start() {
                _rb2D = gameObject.GetComponent<Rigidbody2D>();
            }

            private void Update() {
                _rb2D.AddForce(transform.right * thrust);
            }
        }
    }
}