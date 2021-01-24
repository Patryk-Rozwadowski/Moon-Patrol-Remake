using UnityEngine;

namespace Enemy {
    public class rotation : MonoBehaviour {
        void Update() {
            transform.Rotate(0, 0, 180 * Time.deltaTime);
        }
    }
}