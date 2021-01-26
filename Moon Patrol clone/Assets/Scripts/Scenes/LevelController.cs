using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
    [SerializeField] private ScenesSO scenesScriptableObject;
    private string _gameOverScene, _currentLevel;
    private Scene _stageSummaryScene;

    public void StartGame() {
        NextLevel();
    }

    public void GameOver() {
        SceneManager.LoadScene($"DeadPlayerMenu");
    }

    public void NextLevel() {
        _currentLevel = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name;
        scenesScriptableObject.currentLevel = _currentLevel;
        Debug.Log($"NEXT LEVEL: {scenesScriptableObject.currentLevel}");
        SceneManager.LoadScene(_currentLevel);
    }

    public void RestartLevel() {
        SceneManager.LoadScene($"{scenesScriptableObject.currentLevel}");
    }

    public void SetCurrentLevel() {
        _currentLevel = SceneManager.GetActiveScene().name;
    }

    private void Start() {
        _stageSummaryScene = SceneManager.GetSceneByBuildIndex(4);
    }
}