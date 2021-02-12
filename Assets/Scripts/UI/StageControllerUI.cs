#pragma warning disable 649
using ScriptableObjects.Scenes;
using UnityEngine;

namespace UI {
    public class StageControllerUI : MonoBehaviour {
        [SerializeField] private ScenesSO scenesSO;
        [SerializeField] private UnityEngine.UI.Text stageHudText;

        private void Start() {
            stageHudText.text = scenesSO.currentLevel;
        }
    }
}