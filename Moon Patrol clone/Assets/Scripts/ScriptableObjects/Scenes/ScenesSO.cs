using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableObjects.Scenes {
    [CreateAssetMenu(menuName = "ScriptableObjects/Scenes")]
    public class ScenesSO : ScriptableObject {
        [SerializeField] public Scene stageSummary, gameOverScene;
        [SerializeField] public string currentLevel;
        [SerializeField] public string currentScene;
    }
}