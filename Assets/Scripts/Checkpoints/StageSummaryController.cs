#pragma warning disable 649

using ScriptableObjects.Scenes;
using ScriptableObjects.Score;
using UnityEngine;

namespace Checkpoints {
    public class StageSummaryController : MonoBehaviour {
        [SerializeField] private ScoreStoreSO scoreStore;
        [SerializeField] private ScenesSO scenesSO;

        [SerializeField] private UnityEngine.UI.Text
            stagePoint,
            timeTextField,
            totalScoreOverall;

        private void Start() {
            var levelStrArr = scenesSO.currentLevel.Split(' ');
            var levelStr = levelStrArr[1];

            stagePoint.text = levelStr;
            timeTextField.text = scoreStore.stageTime.ToString();
            totalScoreOverall.text = scoreStore.playerOverallScore.ToString();
        }
    }
}