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
        private float _loadSceneTime = 3f, _loadNextSceneTime = 10f;
        private bool _showStageSummary;

        private string _stageSummary = "StageSummary";

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
            if (scenesScriptableObject.currentScene == _stageSummary) {
                SceneManager.LoadScene(scenesScriptableObject.currentSceneIndex + 1);
                return;
            }
            scenesScriptableObject.currentLevel = GetNameNextLevel();
            SceneManager.LoadScene($"{scenesScriptableObject.currentLevel}");
        }

        private void Start() {
            _stageSummaryScene = SceneManager.GetSceneByBuildIndex(5).name;
            scenesScriptableObject.currentScene = SceneManager.GetActiveScene().name;

            Debug.LogWarning($"{nameof(LevelController)}: Current scene {scenesScriptableObject.currentScene}");
            Debug.LogWarning($"{nameof(LevelController)}: Current Level {scenesScriptableObject.currentLevel}");
            if (scenesScriptableObject.currentScene == _stageSummary) {
                Invoke($"LoadNextLevel", _loadNextSceneTime);
                return;
            }
            scenesScriptableObject.currentLevel = SceneManager.GetActiveScene().name;
            scenesScriptableObject.currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

        public void LoadStageSummary() {
            SceneManager.LoadScene("StageSummary");
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