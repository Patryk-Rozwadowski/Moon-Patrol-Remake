#pragma warning disable 649

using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes {
    public class GameOverSceneController : MonoBehaviour {
        [SerializeField] private ScenesSO scenesSO;
        [SerializeField] private UnityEngine.UI.Text timer;

        private float _timer;
        private LevelController _levelController;

        private void Start() {
            _timer = 10;
        }

        void Update() {
            _timer -= Time.deltaTime;
            var seconds = Mathf.FloorToInt(_timer % 60);
            timer.text = seconds.ToString("00");

            if (_timer <= 1) SceneManager.LoadScene(0);
            if (Input.anyKeyDown) {
                SceneManager.LoadScene($"{scenesSO.currentLevel}");
            }
        }
    }
}