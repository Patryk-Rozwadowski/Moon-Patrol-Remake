using ScriptableObjects.Keyboard;
using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes {
    public class GameOverSceneController : MonoBehaviour {
        [SerializeField] private ScenesSO scenesSO;
        private LevelController _levelController;
        
        void Update() {
            if (Input.anyKeyDown) {
                SceneManager.LoadScene($"{scenesSO.currentLevel}");
            }
        }
    }
}