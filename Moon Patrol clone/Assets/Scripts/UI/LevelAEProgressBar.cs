using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class LevelAEProgressBar : MonoBehaviour {
        public GameObject vehicle;
        public Slider slider;

        void Update() {
            var calculate = vehicle.transform.position.x / 489f * 6;
            slider.value = calculate;
        }
    }
}