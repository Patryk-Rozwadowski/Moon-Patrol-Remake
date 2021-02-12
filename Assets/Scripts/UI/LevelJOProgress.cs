using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class LevelJOProgress : MonoBehaviour {
        public GameObject vehicle;
        public Slider slider;

        private void Update() {
            var calculate = 10 + vehicle.transform.position.x / 402.9f * 6;
            slider.value = calculate;
        }
    }
}