#pragma warning disable 649
using ScriptableObjects.Score;
using UnityEngine;

namespace UI {
    public class ScoreUIController : MonoBehaviour {
        [SerializeField] private UnityEngine.UI.Text text;
        [SerializeField] private ScoreStoreSO _scoreStore;

        private void Update() {
            text.text = $"{_scoreStore.playerOverallScore}";
        }
    }
}