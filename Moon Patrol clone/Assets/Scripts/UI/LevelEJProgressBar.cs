#pragma warning disable 649
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class LevelEJProgressBar : MonoBehaviour {
        [SerializeField] private GameObject vehicle;
        [SerializeField] private Slider slider;

        void Update() {
            var calculate = 5 + (vehicle.transform.position.x / 479.7f) * 6;
            slider.value = calculate;
        }
    }
}