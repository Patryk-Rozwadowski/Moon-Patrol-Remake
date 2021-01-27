#pragma warning disable 649

using ScriptableObjects.Score;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class StageTime : MonoBehaviour {
        [SerializeField] private ScoreStoreSO scoreStore;
        [SerializeField] private UnityEngine.UI.Text stageTimer;

        private float _timer;

        private void Start() {
            _timer = 0;
        }

        void Update() {
            _timer += Time.deltaTime;
            int seconds = Mathf.FloorToInt(_timer);
            stageTimer.text = seconds.ToString("000");
        }

    }
}