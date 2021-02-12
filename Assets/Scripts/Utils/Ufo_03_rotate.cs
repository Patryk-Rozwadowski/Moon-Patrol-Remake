using UnityEngine;

namespace Enemy {
    public class rotation : MonoBehaviour {
        private void Update() {
            transform.Rotate(0, 0, 180 * Time.deltaTime);
        }
    }
}