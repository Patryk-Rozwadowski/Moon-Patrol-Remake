#pragma warning disable 649

using ScriptableObjects.Score;
using UnityEngine;

namespace UI {
    public class StageTime : MonoBehaviour {
        [SerializeField] private ScoreStoreSO scoreStore;
        [SerializeField] private UnityEngine.UI.Text stageTimer;
        private int _seconds;
        private string _secondsString;

        private float _timer;

        private void Start() {
            _timer = 0;
        }

        private void Update() {
            _timer += Time.deltaTime;
            _seconds = Mathf.FloorToInt(_timer);
            scoreStore.stageTime = _seconds;
            stageTimer.text = _seconds.ToString("000");
        }
    }
}