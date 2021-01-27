using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vehicle;

public class LevelController : MonoBehaviour {
    [SerializeField] private ScenesSO scenesScriptableObject;
    private string _gameOverScene, _currentLevel;
    private float _currentIndex;
    private Scene _stageSummaryScene;
    private float _loadSceneTime = 3f;

    public void StartGame() {
        NextLevel();
    }

    public void GameOver() {
        StartCoroutine(LoadGameOverSceneWithDelay());
    }

    public void NextLevel() {
        _currentLevel = GetNameNextLevel();
        scenesScriptableObject.currentLevel = _currentLevel;
        SceneManager.LoadScene(scenesScriptableObject.currentLevel);
    }

    private void Start() {
        _stageSummaryScene = SceneManager.GetSceneByBuildIndex(4);
    }

    private string GetNameNextLevel() {
        var path = SceneUtility.GetScenePathByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);
        var slash = path.LastIndexOf('/');
        var name = path.Substring(slash + 1);
        var dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }

    public void RestartLevel() {
        SceneManager.LoadScene($"{scenesScriptableObject.currentLevel}");
    }

    public void SetCurrentLevel() {
        _currentLevel = SceneManager.GetActiveScene().name;
    }

    private IEnumerator LoadGameOverSceneWithDelay() {
        yield return new WaitForSeconds(_loadSceneTime);
        Debug.Log("ASDAS");
        SceneManager.LoadScene($"DeadPlayerMenu");
    }
}