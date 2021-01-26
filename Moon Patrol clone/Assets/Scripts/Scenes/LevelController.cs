using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
    private int _currentIndex;

    private Scene _gameOverScene;
    private Scene _stageSummaryScene;

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void RestartLevel() {
        SceneManager.LoadScene($"DeadPlayerMenu");
    }

    private void Start() {
        _currentIndex = SceneManager.GetActiveScene().buildIndex;
        _gameOverScene = SceneManager.GetSceneByBuildIndex(5);
        _stageSummaryScene = SceneManager.GetSceneAt(4);
    }
}