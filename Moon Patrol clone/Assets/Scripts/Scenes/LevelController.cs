#pragma warning disable 649

using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes {
    public class LevelController : MonoBehaviour {
        [SerializeField] private ScenesSO scenesScriptableObject;
        private readonly float _loadNextSceneTime = 5f;

        private readonly string
            _stageSummaryAE = "StageSummary A-E",
            _stageSummaryEJ = "StageSummary E-J",
            _stageSummaryJO = "StageSummary J-O",
            _gameFinished = "GameFinished";

        private string _gameOverScene, _currentLevel;
        private bool _showStageSummary;

        private void Start() {
            scenesScriptableObject.currentScene = SceneManager.GetActiveScene().name;

            Debug.LogWarning($"{nameof(LevelController)}: Current scene {scenesScriptableObject.currentScene}");
            Debug.LogWarning($"{nameof(LevelController)}: Current Level {scenesScriptableObject.currentLevel}");

            if (
                scenesScriptableObject.currentScene == _stageSummaryAE ||
                scenesScriptableObject.currentScene == _stageSummaryEJ)
                Invoke("LoadNextLevel", _loadNextSceneTime);

            if (scenesScriptableObject.currentScene == _stageSummaryJO) {
                Debug.Log("GAME FINISHED");
                Invoke("GameFinished", _loadNextSceneTime);
            }

            scenesScriptableObject.currentLevel = SceneManager.GetActiveScene().name;
            scenesScriptableObject.currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

        public void StartGame() {
            LoadNextLevel();
        }

        public void GameOverHandler() {
            Invoke("GameOver", 3f);
        }

        public void GameOver() {
            SceneManager.LoadScene("DeadPlayerMenu");
        }

        private void LoadNextLevel() {
            scenesScriptableObject.currentLevel = GetNameNextLevel();
            SceneManager.LoadScene($"{scenesScriptableObject.currentLevel}");
        }

        private void GameFinished() {
            SceneManager.LoadScene($"{_gameFinished}");
        }

        public void LoadStageSummary() {
            LoadNextLevel();
        }

        private string GetNameNextLevel() {
            var path = SceneUtility.GetScenePathByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);
            var slash = path.LastIndexOf('/');
            var name = path.Substring(slash + 1);
            var dot = name.LastIndexOf('.');
            return name.Substring(0, dot);
        }

        public void SetCurrentLevel() {
            _currentLevel = SceneManager.GetActiveScene().name;
        }
    }
}