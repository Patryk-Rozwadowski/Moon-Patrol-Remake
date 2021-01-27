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
        private float _loadSceneTime = 3f, _loadNextSceneTime = 1f;
        private bool _showStageSummary;

        private string _stageSummary = "StageSummary";

        public void StartGame() {
            NextLevelHandler();
        }

        public void GameOverHandler() {
            Invoke($"GameOver", 3f);
        }
        
        public void GameOver() {
            SceneManager.LoadScene($"DeadPlayerMenu");

        }

        public void NextLevelHandler() {
            LoadStageSummary();
        }

        private void LoadNextLevel() {
            scenesScriptableObject.currentLevel = GetNameNextLevel();
            SceneManager.LoadScene($"{scenesScriptableObject.currentLevel}");
        }

        private void Start() {
            _stageSummaryScene = SceneManager.GetSceneByBuildIndex(5).name;
            
            
            
            Debug.LogWarning($"OIDGJOPIDGJGDJIO {scenesScriptableObject.currentScene}");

            if (scenesScriptableObject.currentScene == _stageSummary) {
                Invoke($"LoadNextLevel", 2);
                return;
            }
            scenesScriptableObject.currentLevel = SceneManager.GetActiveScene().name;
            scenesScriptableObject.currentScene = SceneManager.GetActiveScene().name;

        }

        private void LoadStageSummary() {
            SceneManager.LoadScene("StageSummary");
        }


        private string GetNameNextLevel() {
            // NIE DZIALA 
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

        private IEnumerator LoadGameOverSceneWithDelay() {
            yield return new WaitForSeconds(_loadSceneTime);
        }
    }
}