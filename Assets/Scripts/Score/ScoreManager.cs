#pragma warning disable 649

using ScriptableObjects.Score;
using UnityEngine;

namespace Score {
    public class ScoreManager : MonoBehaviour {
        [SerializeField] private ScoreStoreSO scoreStore;

        private int _bestScore, _overallScore, _stageScore;

        private void Start() {
            scoreStore.playerOverallScore = 0;
        }

        public void AddOverallPlayerScore(int val) {
            scoreStore.playerOverallScore += val;
            Debug.Log($"Score manager: {scoreStore.playerOverallScore}");
        }
    }
}