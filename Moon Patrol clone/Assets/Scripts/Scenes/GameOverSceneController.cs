using ScriptableObjects.Keyboard;
using UnityEngine;

namespace Scenes {
    public class GameOverSceneController : MonoBehaviour {
        private LevelController _levelController;
        
        private void Start() {
            _levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        }

        // Update is called once per frame
        void Update() {
            if (Input.anyKeyDown) {
                _levelController.RestartLevel();
            }
        }
    }
}