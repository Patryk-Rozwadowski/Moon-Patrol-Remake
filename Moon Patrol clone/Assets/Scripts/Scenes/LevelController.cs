using System.Collections;
using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes {
    public class LevelController : MonoBehaviour {
        [SerializeField] private ScenesSO scenesScriptableObject;
        private string _gameOverScene, _currentLevel;
        private float _currentIndex;
        private string _stageSummaryScene;
        private float _loadSceneTime = 3f, _loadNextSceneTime = 5f;
        private bool _showStageSummary;

        private string _stageSummaryAE = "StageSummary A-E";
        private string _stageSummaryEJ = "StageSummary E-J";
        private string _stageSummaryJO = "StageSummary J-O";
        private string _gameFinished = "GameFinished";

        public void StartGame() {
            LoadNextLevel();
        }

        public void GameOverHandler() {
            Invoke($"GameOver", 3f);
        }

        public void GameOver() {
            SceneManager.LoadScene($"DeadPlayerMenu");
        }

        private void LoadNextLevel() {
            scenesScriptableObject.currentLevel = GetNameNextLevel();
            SceneManager.LoadScene($"{scenesScriptableObject.currentLevel}");
        }

        private void GameFinished() {
            SceneManager.LoadScene($"{_gameFinished}");
        }

        private void Start() {
            _stageSummaryScene = SceneManager.GetSceneByBuildIndex(5).name;
            scenesScriptableObject.currentScene = SceneManager.GetActiveScene().name;

            Debug.LogWarning($"{nameof(LevelController)}: Current scene {scenesScriptableObject.currentScene}");
            Debug.LogWarning($"{nameof(LevelController)}: Current Level {scenesScriptableObject.currentLevel}");

            if (
                scenesScriptableObject.currentScene == _stageSummaryAE ||
                scenesScriptableObject.currentScene == _stageSummaryEJ) {
                Invoke($"LoadNextLevel", _loadNextSceneTime);
            }

            if (scenesScriptableObject.currentScene == _stageSummaryJO) {
                Debug.Log("GAME FINISHED");
                Invoke("GameFinished", _loadNextSceneTime);
            }

            scenesScriptableObject.currentLevel = SceneManager.GetActiveScene().name;
            scenesScriptableObject.currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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

        // TODO GAME END

        public void SetCurrentLevel() {
            _currentLevel = SceneManager.GetActiveScene().name;
        }
    }
}